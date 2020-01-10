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
    public class ItemBarcodeDAO : BaseDAO<ItemBarcode>
    {
        public ItemBarcodeDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        public List<ItemBarcode> GetItemBarcodesByItemId(string itemId)
        {
            if (string.IsNullOrEmpty(itemId))
            {
                throw new ArgumentNullException(nameof(itemId));
            }

            return Run(conn =>
            {
                var sql = "SELECT * FROM item_barcode WHERE item_id = @itemId; ";
                return conn.Query<ItemBarcode>(sql, new { itemId }).ToList();
            });
        }
    }
}
