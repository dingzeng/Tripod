using System;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class ItemClsDAO : BaseDAO<ItemCls>
    {
        public ItemClsDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {
        }

        public PagedList<ItemCls> GetItemClss(int pageIndex, int pageSize, string parentId = null)
        {
            string condition = "";
            if (string.IsNullOrEmpty(parentId))
                condition += "AND parent_id = @parentId";

            return GetPaging<ItemCls>(pageIndex: pageIndex, pageSize: pageSize, conditions: condition, param: new { parentId });
        }
    }
}