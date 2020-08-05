using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.Model
{
    public class UserRole
    {
        public long Id { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
