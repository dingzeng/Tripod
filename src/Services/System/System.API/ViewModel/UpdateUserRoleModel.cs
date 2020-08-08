using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.ViewModel
{
    public class UpdateUserRoleModel
    {
        public long UserId { get; set; }

        public List<int> RoleIdList { get; set; }
    }
}
