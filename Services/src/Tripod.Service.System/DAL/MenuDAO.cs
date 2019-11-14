using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Tripod.Service.System.Model;
using Tripod.Framework.Common.DAL;
using Tripod.Framework.Common;

namespace Tripod.Service.System.DAL
{

    public class MenuDAO : BaseDAO<Menu>
    {
        public MenuDAO(ConfigurationOptions options)
            :base(options.ConnectionString)
        {
            
        }
    }
}