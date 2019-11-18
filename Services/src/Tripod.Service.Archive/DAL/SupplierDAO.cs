using System;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class SupplierDAO : BaseDAO<Supplier>
    {
        public SupplierDAO(ConfigurationOptions options)
            :base(options.ConnectionString)
        {
        }

        public PagedList<Supplier> GetSuppliers(int pageIndex = 1,int pageSize = int.MaxValue,int? supplierRegionId = null)
        {
            var inner = "SELECT * FROM supplier";
            var conditions = "";
            if(supplierRegionId.HasValue){
                conditions += "AND region_id = @regionId";
            }

            return this.GetPaging<Supplier>(
                innerQuery: inner,
                pageIndex: pageIndex,
                pageSize: pageSize,
                conditions: conditions,
                param:new{});
        }
    }
}