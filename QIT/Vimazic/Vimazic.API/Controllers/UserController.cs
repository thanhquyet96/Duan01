using EPS.TSC.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using EPS.TSC.API.Helpers;
using EPS.TSC.Data.Entities;
using EPS.TSC.Service.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EPS.Utils.Repository;
using EPS.TSC.Service.Dtos.Common;
using EPS.TSC.Service;
using System.Collections.Generic;

namespace EPS.TSC.API.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [Authorize]
    public class UserController : BaseController
    {
        private UserManager<USER> _userManager;
        private AuthorizationService _userService;

        public UserController(UserManager<USER> userManager, AuthorizationService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(UserIdentity.Username);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok(true);
            }
            else
            {
                throw new Exception(string.Format(". \n\r", result.Errors.Select(x => x.Description)));
            }
        }

        [CustomAuthorize(Privilege.ViewUser)]
        [HttpGet("list")]
        public async Task<IActionResult> GetUsers(UserGridPagingModel pagingModel)
        {
            var predicates = pagingModel.GetPredicates();
            predicates.Add(x => x.IsExploitingUser == null || !x.IsExploitingUser.Value);
            return Ok(await BaseService.FilterPagedAsync<USER, UserGridDto>(pagingModel, predicates.ToArray()));
        }
        //user exploiting
        [CustomAuthorize(Privilege.ViewExploitationUser)]
        [HttpGet("exploiting")]
        public async Task<IActionResult> GetExploitingUsers(UserGridPagingModel pagingModel)
        {
            var predicates = pagingModel.GetPredicates();
            predicates.Add(x => x.IsExploitingUser != null && x.IsExploitingUser.Value);
            return Ok(await BaseService.FilterPagedAsync<USER, UserGridDto>(pagingModel, predicates.ToArray()));
        }


        [CustomAuthorize(Privilege.ViewUser)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await BaseService.FindAsync<USER, UserDetailDto>(id));
        }

        [CustomAuthorize(Privilege.ManageUser)]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto newUser)
        {
            var entityUser = Mapper.Map<USER>(newUser);

            var result = await _userManager.CreateAsync(entityUser, newUser.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(".", result.Errors.Select(x => x.Description));

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }

                return BadRequest(ModelState);
            }
            else
            {
                await _userService.SaveUserRoles(entityUser.Id, newUser.RoleIds);
                // Must log manually if not using BaseService
                Logger.Log(Microsoft.Extensions.Logging.LogLevel.Information, default(EventId), new ExtraPropertyLogger("User {username} added new {entity} {identifier}", UserIdentity.Username, typeof(USER).Name, entityUser.ToString()).AddProp("data", entityUser), null, ExtraPropertyLogger.Formatter);
            }

            return Ok(entityUser.Id);
        }
     
        [CustomAuthorize(Privilege.ManageUser, Privilege.ManageExploitationUser)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto editedUser)
        {
            var user = await Repository.FindAsync<USER>(id);
            await BaseService.UpdateAsync<USER, UserUpdateDto>(id, editedUser);

            await _userService.SaveUserRoles(id, editedUser.RoleIds);
            if (!string.IsNullOrEmpty(editedUser.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, editedUser.NewPassword);

                if (!result.Succeeded)
                {
                    return BadRequest(string.Join(".", result.Errors.Select(x => x.Description)));
                }
                else
                {
                    // Must log manually if not using BaseService
                    Logger.Log(Microsoft.Extensions.Logging.LogLevel.Information, default(EventId), string.Format("User {0} has changed password for user {1}", UserIdentity.Username, user.ToString()), null, ExtraPropertyLogger.Formatter);
                }
            }

            return Ok(true);
        }

        [CustomAuthorize(Privilege.ManageUser, Privilege.ManageExploitationUser)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await BaseService.DeleteAsync<USER, int>(id);

            return Ok(true);
        }

        [CustomAuthorize(Privilege.ManageUser, Privilege.ManageExploitationUser)]
        [HttpGet("{id}/privileges")]
        public async Task<IActionResult> GetUserPrivileges(int id)
        {
            return Ok(await _userService.GetUserPrivileges(id));
        }

        [CustomAuthorize(Privilege.ManageUser, Privilege.ManageExploitationUser)]
        [HttpPut("{id}/privileges")]
        public async Task<IActionResult> SaveUserPrivileges(int id, string[] privileges)
        {
            await _userService.SaveUserPrivileges(id, privileges);

            return Ok();
        }
        //multiple delete 
        [CustomAuthorize(Privilege.ManageUser, Privilege.ManageExploitationUser)]
        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest();
            }
            try
            {
                var userIds = ids.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                await BaseService.DeleteAsync<USER, int>(userIds);
                return Ok(true);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-list-users/{unitId}")]
        public async Task<IActionResult> GetListUserByUnitId(int? unitId)
        {
            return Ok(await BaseService.FilterEntity<USER, SelectItem>(x => x.UNIT_ID == unitId).Select(u => u.Text).ToListAsync());
        }
    }
}
