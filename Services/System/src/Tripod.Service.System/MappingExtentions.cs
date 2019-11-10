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

        public static Permission ToEntity(this PermissionDTO dto)
        {
            return new Permission()
            {
                Code = dto.Code,
                MenuCode = dto.MenuCode,
                Type = (Tripod.Service.System.Model.PermissionType)dto.Type,
                Name = dto.Name
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
    }
}