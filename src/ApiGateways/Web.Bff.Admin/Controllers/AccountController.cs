using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Web.Bff.Admin.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            return Content("这是登录页面");
        }

        [HttpPost]
        [Route("cookie-login")]
        public async Task<IActionResult> CookieLogin([FromBody] LoginModel model)
        {
            // TODO check login and get userId
            string userId = model.UserName;

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim("userId", userId));
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return Content("登录完成，已写入Cookie");
        }

        [HttpPost]
        [Route("jwt-login")]
        public async Task<IActionResult> JwtLogin([FromServices] SymmetricSecurityKey securityKey, [FromBody] LoginModel model)
        {
            // TODO check login and get userId
            string userId = model.UserName;

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("userId", userId));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "localhost", audience: "localhost", claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: signingCredentials);
            var content = new JwtSecurityTokenHandler().WriteToken(token);
            return Content(content);
        }
    }
}
