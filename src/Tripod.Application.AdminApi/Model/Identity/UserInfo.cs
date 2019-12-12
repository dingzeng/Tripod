using System;
using System.Collections.Generic;
using Tripod.Service.System;

namespace Tripod.Application.AdminApi.Model.Identity
{
    public class UserInfo
    {
        /// <summary>
        /// 用户有【查看】权限的菜单集合
        /// </summary>
        /// <value></value>
        public List<MenuNode> Menus { get; set; }

        /// <summary>
        /// 用户拥有的操作权限集合
        /// </summary>
        /// <value></value>
        public List<PermissionDTO> Permissions { get; set; }
        
        /// <summary>
        /// 用户姓名
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        /// <value></value>
        public string Avatar { get; set; }

        /// <summary>
        /// 用户介绍
        /// </summary>
        /// <value></value>
        public string Introduction { get; set; }
    }
}