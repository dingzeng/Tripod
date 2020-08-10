using System;
using System.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.API.Infrastructure
{
    public class SystemContextSeed
    {
        public void Seed(SystemContext context)
        {
            using (context)
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetUsers());
                }

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(GetRoles());
                }

                if (!context.Menus.Any())
                {
                    context.Menus.AddRange(GetMenus());
                }

                if (!context.Permissions.Any())
                {
                    context.Permissions.AddRange(GetPermissions());
                }

                context.SaveChanges();
            }
        }

        private IEnumerable<User> GetUsers()
        {
            yield return new User()
            {
                BranchId = "00",
                BranchName = "总部",
                Username = "9001",
                Password = "888888",
                Name = "张三",
                Mobile = "15871369831",
                Status = true,
                ItemDepartmentPermissionFlag = PermissionRangeFlag.All,
                SupplierPermissionFlag = PermissionRangeFlag.All
            };
        }

        private IEnumerable<Role> GetRoles()
        {
            yield return new Role()
            {
                Name = "管理员",
                Memo = "种子数据"
        };
    }

    private IEnumerable<Menu> GetMenus()
    {
        return new List<Menu>()
            {
                new Menu{ Code = "ARCHIVE", ParentCode = "", Path = "", Name = "档案", Icon = "", IsLeaf = false, Sequence = 1 },
                new Menu{ Code = "PURCHASE", ParentCode = "", Path = "", Name = "采购", Icon = "", IsLeaf = false, Sequence = 2 },
                new Menu{ Code = "STOCK", ParentCode = "", Path = "", Name = "库存", Icon = "", IsLeaf = false, Sequence = 3 },
                new Menu{ Code = "DELIVERY", ParentCode = "", Path = "", Name = "配送", Icon = "", IsLeaf = false, Sequence = 4 },
                new Menu{ Code = "SALE", ParentCode = "", Path = "", Name = "批发", Icon = "", IsLeaf = false, Sequence = 5 },
                new Menu{ Code = "RETAIL", ParentCode = "", Path = "", Name = "零售", Icon = "", IsLeaf = false, Sequence = 6 },
                new Menu{ Code = "SETTLEMENT", ParentCode = "", Path = "", Name = "结算", Icon = "", IsLeaf = false, Sequence = 7 },
                new Menu{ Code = "REPORT", ParentCode = "", Path = "", Name = "报表", Icon = "", IsLeaf = false, Sequence = 8 },

                // SYSTEM
                new Menu{ Code = "SYSTEM", ParentCode = "", Path = "", Name = "系统", Icon = "", IsLeaf = false, Sequence = 9 },
                new Menu{ Code = "SYSTEM_USER_MANAGE", ParentCode = "SYSTEM", Path = "", Name = "用户管理", Icon = "", IsLeaf = false, Sequence = 1 },
                new Menu{ Code = "SYSTEM_ROLE", ParentCode = "SYSTEM_USER_MANAGE", Path = "/system/role", Name = "角色管理", Icon = "", IsLeaf = true, Sequence = 1 },
                new Menu{ Code = "SYSTEM_USER", ParentCode = "SYSTEM_USER_MANAGE", Path = "/system/user", Name = "用户管理", Icon = "", IsLeaf = true, Sequence = 2 },
                new Menu{ Code = "SYSTEM_SETTING", ParentCode = "SYSTEM", Path = "", Name = "系统设置", Icon = "", IsLeaf = false, Sequence = 2 },
            };
    }

    private IEnumerable<Permission> GetPermissions()
    {
        return new List<Permission>()
            {
                new Permission{ MenuCode = "SYSTEM_ROLE", Code = "SYSTEM_ROLE_VIEW", Name = "查看" },
                new Permission{ MenuCode = "SYSTEM_ROLE", Code = "SYSTEM_ROLE_CREATE", Name = "新增" },
                new Permission{ MenuCode = "SYSTEM_ROLE", Code = "SYSTEM_ROLE_MODIFY", Name = "修改" },
                new Permission{ MenuCode = "SYSTEM_ROLE", Code = "SYSTEM_ROLE_DELETE", Name = "删除" },

                new Permission{ MenuCode = "SYSTEM_USER", Code = "SYSTEM_USER_VIEW", Name = "查看" },
                new Permission{ MenuCode = "SYSTEM_USER", Code = "SYSTEM_USER_CREATE", Name = "新增" },
                new Permission{ MenuCode = "SYSTEM_USER", Code = "SYSTEM_USER_MODIFY", Name = "修改" },
                new Permission{ MenuCode = "SYSTEM_USER", Code = "SYSTEM_USER_DELETE", Name = "删除" },
            };
    }
}
}
