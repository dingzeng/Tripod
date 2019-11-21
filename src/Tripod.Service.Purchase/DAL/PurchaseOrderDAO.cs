using System;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Purchase.Model;

namespace Tripod.Service.Purchase.DAL
{
    public class PurchaseOrderDAO : BaseDAO<PurchaseOrder>
    {
        public PurchaseOrderDAO(ConfigurationOptions options)
            :base(options.ConnectionString)
        {
        }
    }
}