using EPS.TSC.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using EPS.TSC.API.Helpers;
using EPS.TSC.Data.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;
using EPS.TSC.Service.Dtos.Role;
using EPS.TSC.Service.Dtos.Common;
using EPS.TSC.Service;

namespace EPS.TSC.API.Controllers
{
    [Produces("application/json")]
    [Route("api/roles")]
    [Authorize]
    public class RoleController : BaseController
    {
        private AuthorizationService _userService;

        public RoleController(AuthorizationService userService)
        {
            _userService = userService;
        }

        //list all
        [CustomAuthorize(Privilege.ViewRole, Privilege.ManageRole)]
        [HttpGet]
        public async Task<IActionResult> GetListRoles(RoleGridPagingModel pagingModel)
        {
            var predicates = pagingModel.GetPredicates();
            predicates.Add(x => x.IsExploitingRole == null || !x.IsExploitingRole.Value);
            var model = await BaseService.FilterPagedAsync<ROLE, RoleGridDto>(pagingModel, predicates.ToArray());
            return Ok(model);
        }
        [CustomAuthorize(Privilege.ViewExploitationRole, Privilege.ManageExploitationRole)]
        [HttpGet("exploiting")]
        public async Task<IActionResult> GetListExploitingRoles(RoleGridPagingModel pagingModel)
        {
            var predicates = pagingModel.GetPredicates();
            predicates.Add(x => x.IsExploitingRole != null && x.IsExploitingRole.Value);
            var model = await BaseService.FilterPagedAsync<ROLE, RoleGridDto>(pagingModel, predicates.ToArray());
            return Ok(model);
        }
        //get privileges by roleId  
        [CustomAuthorize(Privilege.ViewRole, Privilege.ManageRole, Privilege.ViewExploitationRole, Privilege.ManageExploitationRole)]
        [HttpGet("{id}/privileges")]
        public async Task<IActionResult> GetRolePrivieleges(int id)
        {
            return Ok(await _userService.GetRolePrivileges(id));
        }

        [CustomAuthorize(Privilege.ManageRole, Privilege.ManageExploitationRole)]
        [HttpPut("{id}/privileges")]
        public async Task<IActionResult> SaveRolePrivileges(int id, string[] privileges)
        {
            await _userService.SaveRolePrivileges(id, privileges);

            return Ok();
        }

        //detail
        [CustomAuthorize(Privilege.ViewRole, Privilege.ManageRole, Privilege.ViewExploitationRole, Privilege.ManageExploitationRole)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            return Ok(await BaseService.FindAsync<ROLE, RoleDetailDto>(id));
        }

        //create
        [CustomAuthorize(Privilege.ManageRole)]
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateDto roleCreateDto)
        {
            await BaseService.CreateAsync<ROLE, RoleCreateDto>(roleCreateDto);
            return Ok();
        }
        //create exploitation role
        [CustomAuthorize(Privilege.ManageExploitationRole)]
        [HttpPost("exploiting")]
        public async Task<IActionResult> CreateExploitationRole(ExploitationRoleCreateDto roleCreateDto)
        {
            await BaseService.CreateAsync<ROLE, ExploitationRoleCreateDto>(roleCreateDto);
            return Ok();
        }

        //update
        [CustomAuthorize(Privilege.ManageRole, Privilege.ManageExploitationRole)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleUpdateDto roleUpdateDto)
        {
            await BaseService.UpdateAsync<ROLE, RoleUpdateDto>(id, roleUpdateDto);
            return Ok(true);
        }

        [CustomAuthorize(Privilege.ManageRole, Privilege.ManageExploitationRole)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await BaseService.DeleteAsync<ROLE, int>(id);
            return Ok(true);
        }

        //multiple delete 
        [CustomAuthorize(Privilege.ManageRole, Privilege.ManageExploitationRole)]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoles(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest();
            }
            try
            {
                var roleIds = ids.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                await BaseService.DeleteAsync<ROLE, int>(roleIds);
                return Ok(true);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
