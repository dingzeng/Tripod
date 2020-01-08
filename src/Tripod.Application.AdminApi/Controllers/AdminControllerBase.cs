using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tripod.Application.AdminApi.Model.Identity;

namespace Tripod.Application.AdminApi.Controllers
{
    public class AdminControllerBase : ControllerBase
    {
        public UserInfo CurrentUser
        {
            get
            {
                var cache = this.HttpContext.RequestServices.GetService<IDistributedCache>();

                StringValues header;
                if (this.HttpContext.Request.Headers.TryGetValue("X-Token", out header))
                {
                    var token = header.ToString();
                    var content = cache.GetString(token);
                    return JsonConvert.DeserializeObject<UserInfo>(content);
                }
                else
                {
                    throw new ApiException(ApiCode.ILLEGAL_TOKEN);
                }
            }
        }
    }
}
