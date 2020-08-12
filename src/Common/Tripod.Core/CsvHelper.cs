using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Tripod.Core
{
    public static class CsvHelper
    {
        public static IEnumerable<T> ReadFromCsv<T>(string csvFilePath)
        {
            if(!File.Exists(csvFilePath)) {
                throw new FileNotFoundException("文件不存在");
            }

            var lines = File.ReadAllLines(csvFilePath);
            if(lines.Length < 1) {
                throw new Exception("格式错误：缺少标题");
            }

            var type = typeof (T);

            var header = lines[0].Split(',');
            foreach (var line in lines.Skip(1))
            {
                if(string.IsNullOrEmpty(line)) {
                    continue;
                }

                var row = line.Split(',');
                if(row.Length != header.Length) {
                    throw new Exception("格式错误：行列数和标题列数不一致");
                }

                var obj = Activator.CreateInstance(type);
                for (int index = 0; index < header.Length; index++)
                {
                    var colName = header[index];
                    var value = row[index].Trim();

                    var property = type.GetProperty(colName);
                    property.SetValue(obj, property.GetPropertyValue(value));
                }
                yield return (T)obj;
            }
        }

        private static object GetPropertyValue(this PropertyInfo property, string value)
        {
            var typeName = property.PropertyType.Name;
            switch (typeName)
            {
                case "Int32": return Convert.ToInt32(value);
                case "Int64": return Convert.ToInt64(value);
                case "Boolean": return Convert.ToBoolean(value);
                case "String":
                default: return value;
            }
        }
    }
}