using System;
using Tripod.Service.System.Model;

namespace Tripod.Service.System
{
    public static class MappingExtentions
    {
        public static Menu ToEntity(this MenuDTO dto)
        {
            return new Menu()
            {
                Code = dto.Code,
                ParentCode = dto.ParentCode,
                Path = dto.Path,
                IsLeaf = dto.IsLeaf,
                Name = dto.Name
            };
        }

        public static MenuDTO ToDto(this Menu entity)
        {
            return new MenuDTO()
            {
                Code = entity.Code,
                ParentCode = entity.ParentCode,
                Path = entity.Path,
                IsLeaf = entity.IsLeaf,
                Name = entity.Name
            };
        }

        public static PermissionDTO ToDto(this Permission entity)
        {
            return new PermissionDTO()
            {
                Code = entity.Code,
                MenuCode = entity.MenuCode,
                Type = (PermissionType)entity.Type,
                Name = entity.Name
            };
        }

        public static PermissionApiDTO ToDto(this PermissionApi entity)
        {
            return new PermissionApiDTO()
            {
                Id = entity.Id,
                PermissionCode = entity.PermissionCode,
                Url = entity.Url,
                Method = entity.Method
            };
        }

        public static Role ToEntity(this RoleDTO dto)
        {
            return new Role()
            {
                Id = dto.Id,
                Name = dto.Name,
                Memo = dto.Memo
            };
        }

        public static RoleDTO ToDto(this Role entity)
        {
            return new RoleDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Memo = entity.Memo
            };
        }

        public static User ToEntity(this UserDTO dto)
        {
            return new User()
            {
                Id = dto.Id,
                BranchCode = dto.BranchCode,
                Username = dto.Username,
                Password = dto.Password,
                Name = dto.Name,
                Mobile = dto.Mobile,
                Status = dto.Status,
                ItemDepartmentPermissionFlag = dto.ItemDepartmentPermissionFlag,
                SupplierPermissionFlag = dto.SupplierPermissionFlag
            };
        }

        public static UserDTO ToDto(this User entity)
        {
            return new UserDTO()
            {
                Id = entity.Id,
                BranchCode = entity.BranchCode,
                Username = entity.Username,
                Password = entity.Password,
                Name = entity.Name,
                Mobile = entity.Mobile,
                Status = entity.Status,
                ItemDepartmentPermissionFlag = entity.ItemDepartmentPermissionFlag,
                SupplierPermissionFlag = entity.SupplierPermissionFlag
            };
        }
    }
}