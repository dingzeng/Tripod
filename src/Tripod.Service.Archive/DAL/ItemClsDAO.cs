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
            :base(options.ConnectionString)
        {
        }

        public PagedList<ItemCls> GetItemClss(int pageIndex, int pageSize, string parentId = null)
        {
            throw new NotImplementedException();
        }
    }
}