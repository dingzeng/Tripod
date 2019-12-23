using System;

namespace Tripod.Application.AdminApi.Attributes
{
    public class PermissionApiAttribute: Attribute
    {
        public string Code { get; set; }

        public PermissionApiAttribute(string code)
        {
            this.Code = code;
        }
    }
}