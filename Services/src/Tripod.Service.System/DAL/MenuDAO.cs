using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Tripod.Service.System.Model;
using Tripod.Framework.Common.DAL;

namespace Tripod.Service.System.DAL
{

    public class MenuDAO : BaseDAO<Menu>
    {
        public MenuDAO()
            :base("")
        {
            
        }
    }
}