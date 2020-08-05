using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.Model
{
    public enum PermissionType
    {
        View = 0,
        Create = 1,
        Update = 2,
        Delete = 3,
        Approve = 4,
        Other = 9
    }
}
