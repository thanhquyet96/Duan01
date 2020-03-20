using EPS.TSC.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EPS.TSC.API.Helpers;
using EPS.TSC.Data.Entities;
using EPS.TSC.Data;

namespace EPS.TSC.API.Controllers
{
    [Route("api/token")]
    public class TokenController : BaseController
    {
        //some config in the appsettings.json
        private IOptions<Audience> _settings;
        //repository to handler the sqlite database

        public TokenController(IOptions<Audience> settings)
        {
            this._settings = settings;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth(TokenRequestParams parameters)
        {
            var data = new TSCContext();
            var model = data.USERS.ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                // Verify client's identification
                var client = await Context.IDENTITY_CLIENTS.SingleOrDefaultAsync(x => x.IDENTITY_CLIENT_ID == parameters.client_id && x.SECRET_KEY == parameters.client_secret);

                if (client == null)
                {
                    return BadRequest("Unauthorized client.");
                }

                if (parameters.grant_type == "password")
                {
                    return await DoPassword(parameters, client);
                }
                else if (parameters.grant_type == "refresh_token")
                {
                    return await DoRefreshToken(parameters, client);
                }
                else if (parameters.grant_type == "invalidate_token")
                {
                    return await DoInvalidateToken(parameters);
                }
                else
                {
                    return BadRequest("Invalid grant type.");
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private async Task<IActionResult> DoInvalidateToken(TokenRequestParams parameters)
        {
            var token = await Context.IDENTITY_REFRESH_TOKENS.FirstOrDefaultAsync(x => x.REFRESH_TOKEN == parameters.refresh_token);

            if (token == null)
            {
                return Ok();
            }

            Context.Remove(token);

            await Context.SaveChangesAsync();

            return Ok();
        }

        //scenario 1 ： get the access-token by username and password
        private async Task<IActionResult> DoPassword(TokenRequestParams parameters, IDENTITY_CLIENT client)
        {
            //validate the client_id/client_secret/username/password                                          
            var user = await Context.USERS.FirstOrDefaultAsync(x => x.UserName == parameters.username);

            if (user == null)
            {
                return BadRequest("Invalid user infomation.");
            }

            var passwordHasher = new PasswordHasher<USER>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, parameters.password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return BadRequest("Invalid user infomation.");
            }

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            var rToken = new IDENTITY_REFRESH_TOKEN
            {
                CLIENT_ID = parameters.client_id,
                REFRESH_TOKEN = refresh_token,
                IDENTITY_REFRESH_TOKEN_ID = Guid.NewGuid().ToString(),
                ISSUED_UTC = DateTime.UtcNow,
                EXPIRES_UTC = DateTime.UtcNow.AddDays(client.REFRESH_TOKEN_LIFE_TIME),
                IDENTITY = parameters.username
            };

            //store the refresh_token
            Context.IDENTITY_REFRESH_TOKENS.Add(rToken);

            await Context.SaveChangesAsync();

            return Ok(GetJwt(parameters.client_id, refresh_token, user));
        }

        //scenario 2 ： get the access_token by refresh_token
        private async Task<IActionResult> DoRefreshToken(TokenRequestParams parameters, IDENTITY_CLIENT client)
        {
            var token = await Context.IDENTITY_REFRESH_TOKENS.FirstOrDefaultAsync(x => x.REFRESH_TOKEN == parameters.refresh_token);

            if (token == null)
            {
                return BadRequest("Token not found.");
            }

            if (token.IS_EXPIRED)
            {
                // Remove refresh token if expired
                Context.IDENTITY_REFRESH_TOKENS.Remove(token);
                await Context.SaveChangesAsync();

                return BadRequest("Token has expired.");
            }

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            //remove the old refresh_token and add a new refresh_token
            Context.IDENTITY_REFRESH_TOKENS.Remove(token);

            Context.IDENTITY_REFRESH_TOKENS.Add(new IDENTITY_REFRESH_TOKEN
            {
                CLIENT_ID = parameters.client_id,
                REFRESH_TOKEN = refresh_token,
                IDENTITY_REFRESH_TOKEN_ID = Guid.NewGuid().ToString(),
                ISSUED_UTC = DateTime.UtcNow,
                EXPIRES_UTC = DateTime.UtcNow.AddDays(client.REFRESH_TOKEN_LIFE_TIME),
                IDENTITY = token.IDENTITY
            });

            await Context.SaveChangesAsync();

            var user = await Context.USERS.SingleOrDefaultAsync(x => x.UserName == token.IDENTITY);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            return Ok(GetJwt(parameters.client_id, refresh_token, user));
        }

        private string GetJwt(string client_id, string refresh_token, USER user)
        {
            var now = DateTime.UtcNow;

            var privileges = user.USER_PRIVILEGES.Select(x => x.PRIVILEGE_ID)
                .Union(user.USER_ROLES.SelectMany(x => x.ROLE.ROLE_PRIVILEGES.Select(y => y.PRIVILEGE_ID)))
                .Distinct()
                .ToList();

            var claims = new Claim[]
            {
                new Claim(CustomClaimTypes.ClientId, client_id),
                new Claim(CustomClaimTypes.UserId, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.FULL_NAME, ClaimValueTypes.String),
                new Claim(ClaimTypes.NameIdentifier, user.UserName, ClaimValueTypes.String),
                new Claim(CustomClaimTypes.Privileges, string.Join(",", privileges)),
                new Claim(CustomClaimTypes.UnitId, user.UNIT_ID.ToString())
            };

            var symmetricKeyAsBase64 = _settings.Value.Secret;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var expires = now.Add(TimeSpan.FromMinutes(20));

            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Iss,
                audience: _settings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires,
                refresh_token,
                fullName = user.FULL_NAME,
                username = user.UserName,
                unitId = user.UNIT_ID,
                privileges
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}
