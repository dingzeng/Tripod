using System;

namespace Tripod.Framework.DapperExtentions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string columnName)
        {
            Name = columnName;
        }
        
        public string Name { get; set; }
    }
}