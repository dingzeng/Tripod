using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GrpcSystem;
using Identity.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Identity.API.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserGrpc.UserGrpcClient _userClient;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userClient"></param>
        public AccountController(UserGrpc.UserGrpcClient userClient)
        {
            _userClient = userClient;
        }

        /// <summary>
        /// JWT 登录
        /// </summary>
        /// <param name="securityKey"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromServices] SymmetricSecurityKey securityKey, [FromBody] LoginModel model)
        {
            var request = new CheckUsernameAndPasswordRequest()
            {
                Username = model.UserName,
                Password = model.Password
            };
            var response = await _userClient.CheckUsernameAndPasswordAsync(request);
            if(String.IsNullOrEmpty(response.UserId))
            {
                return NotFound();
            }

            string userId = response.UserId;
            string username = response.Username;

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("userId", userId));
            claims.Add(new Claim("username", username));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    issuer: "localhost",
                    audience: "localhost",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signingCredentials);
            var content = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(content);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
