using System;
using System.API.Model;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tripod.Core;

namespace System.API.Infrastructure
{
    public class SystemContextSeed
    {
        public void Seed(SystemContext context)
        {
            using (context)
            {
                if (!context.Users.Any(u => u.Username == "administrator"))
                {
                    context.Users.Add(GetAdministrator());
                }

                SeedMenus(context);
                SeedPermissions(context);

                context.SaveChanges();
            }
        }

        private void SeedMenus(SystemContext context)
        {
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE [Menu]");
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "Setup/menus.csv");
            var menus = CsvHelper.ReadFromCsv<Menu>(filePath);
            context.Menus.AddRange(menus);
        }

        private void SeedPermissions(SystemContext context)
        {
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "Setup/permissions.csv");
            var filePermissions = CsvHelper.ReadFromCsv<Permission>(filePath);
            var dbPermissions = context.Permissions.ToList();

            var comparer = new PermissionEqualityComparer();
            var doUpdatePermissions = dbPermissions.Intersect(filePermissions, comparer).ToList();
            var doInsertPermissions = filePermissions.Except(doUpdatePermissions, comparer);
            var doDeletePermission = dbPermissions.Except(doUpdatePermissions, comparer);

            foreach (var item in doUpdatePermissions)
            {
                var entity = context.Permissions.First(p => p.Code == item.Code);
                entity.Name = item.Name;
                entity.MenuCode = item.MenuCode;
            }
            context.Permissions.AddRange(doInsertPermissions);
            context.Permissions.RemoveRange(doDeletePermission);
        }

        private User GetAdministrator()
        {
            return new User()
            {
                BranchId = "",
                BranchName = "",
                Username = "administrator",
                Password = "888888",
                Name = "超级管理员",
                Mobile = "",
                Status = true,
                ItemDepartmentPermissionFlag = PermissionRangeFlag.All,
                SupplierPermissionFlag = PermissionRangeFlag.All
            };
        }
    }

    public class PermissionEqualityComparer : EqualityComparer<Permission>
    {
        public override bool Equals([AllowNull] Permission x, [AllowNull] Permission y)
        {
            return x.Code == y.Code;
        }

        public override int GetHashCode([DisallowNull] Permission obj)
        {
            return obj.Code.GetHashCode();
        }
    }
}
