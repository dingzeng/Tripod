using System;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class SupplierRegionDAO : BaseDAO<SupplierRegion>
    {
        public SupplierRegionDAO(ConfigurationOptions options)
            :base(options.ConnectionString)
        {
        }
    }
}