using System;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Stock.Model;

namespace Tripod.Service.Stock.DAL
{
    public class ItemStockDAO : BaseDAO<ItemStock>
    {
        public ItemStockDAO(ConfigurationOptions options)
            :base(options.ConnectionString)
        {
        }
    }
}