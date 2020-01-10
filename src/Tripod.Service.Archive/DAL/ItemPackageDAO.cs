using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class ItemPackageDAO : BaseDAO<ItemBarcode>
    {
        public ItemPackageDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        public List<ItemPackage> GetItemPackagesByItemId(string itemId)
        {
            if (string.IsNullOrEmpty(itemId))
            {
                throw new ArgumentNullException(nameof(itemId));
            }

            return Run(conn =>
            {
                var sql = "SELECT * FROM item_package WHERE item_id = @itemId; ";
                return conn.Query<ItemPackage>(sql, new { itemId }).ToList();
            });
        }
    }
}
