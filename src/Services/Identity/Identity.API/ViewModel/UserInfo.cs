using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.ViewModel
{
    public class UserInfo
    {
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Introduction { get; set; }

        public IList<GrpcSystem.MenuDTO> Menus { get; set; }

		public IList<GrpcSystem.PermissionDTO> Permissions { get; set; }
    }
}
