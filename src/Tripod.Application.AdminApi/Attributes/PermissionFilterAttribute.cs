using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using Tripod.Application.AdminApi.Model.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Tripod.Application.AdminApi.Attributes
{
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        public string Code { get; set; }

        public PermissionFilterAttribute(string code)
        {
            this.Code = code;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var cache = context.HttpContext.RequestServices.GetService<IDistributedCache>();

            StringValues header;
            if (context.HttpContext.Request.Headers.TryGetValue("X-Token", out header))
            {
                var token = header.ToString();
                var content = cache.GetString(token);
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(content);
                if (!userInfo.Permissions.Exists(p => p.Code == this.Code))
                {
                    throw new ApiException(ApiCode.PERMISSION_DENIED, "无操作权限");
                }
            }
        }
    }
}