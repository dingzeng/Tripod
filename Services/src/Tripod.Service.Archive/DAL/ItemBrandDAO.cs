using System;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class ItemBrandDAO : BaseDAO<ItemBrand>
    {
        public ItemBrandDAO(ConfigurationOptions options)
            :base(options.ConnectionString)
        {
        }
    }
}