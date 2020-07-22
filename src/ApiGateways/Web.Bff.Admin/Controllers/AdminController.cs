using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Bff.Admin.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("cookie")]
        [Authorize]
        public async Task<IActionResult> Cookie()
        {
            return Content("Cookie Success");
        }

        [HttpGet]
        [Route("jwt")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Jwt()
        {
            return Content("Jwt Success");
        }

        [HttpGet]
        [Route("any")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme + "," + JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Any()
        {
            return Content("Any Success");
        }
    }
}
