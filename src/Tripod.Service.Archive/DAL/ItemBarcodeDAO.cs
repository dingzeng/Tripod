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

        public bool IsExistsItemBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                throw new ArgumentNullException(nameof(barcode));

            var sql = "SELECT (SELECT COUNT(1) FROM item WHERE barcode = @barcode) + (SELECT COUNT(1) FROM item WHERE barcode = @barcode) AS count;";
            return Run(conn =>
            {
                return conn.Query<int>(sql, new { barcode }).First() > 0;
            });
        }
    }
}
