using System;
using System.Collections.Generic;

namespace Tripod.Application.AdminApi.Model.User
{
    public class UpdateRolesModel
    {
        public int UserId { get; set; }

        public List<int> RoleIdList { get; set; }
    }
}