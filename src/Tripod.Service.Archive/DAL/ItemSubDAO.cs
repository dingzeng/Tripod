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
    public class ItemSubDAO : BaseDAO<ItemBarcode>
    {
        public ItemSubDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        public List<ItemSub> GetItemSubsByItemId(string itemId)
        {
            if (string.IsNullOrEmpty(itemId))
            {
                throw new ArgumentNullException(nameof(itemId));
            }

            return Run(conn =>
            {
                var sql = "SELECT * FROM item_sub WHERE item_id = @itemId; ";
                return conn.Query<ItemSub>(sql, new { itemId }).ToList();
            });
        }
    }
}
