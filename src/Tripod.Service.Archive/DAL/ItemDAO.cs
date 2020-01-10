using System;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;
using Tripod.Framework.DapperExtentions;

namespace Tripod.Service.Archive.DAL
{
    public class ItemDAO : BaseDAO<Item>
    {
        private readonly ItemBarcodeDAO _itemBarcodeDao;
        private readonly ItemPackageDAO _itemPackageDao;
        private readonly ItemSubDAO _itemSubDao;

        public ItemDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {
            _itemBarcodeDao = new ItemBarcodeDAO(options);
            _itemPackageDao = new ItemPackageDAO(options);
            _itemSubDao = new ItemSubDAO(options);
        }

        public PagedList<ItemDTO> Query(
            int pageIndex = 1,
            int pageSize = 20,
            string status = "",
            string primarySupplierId = "",
            string itemClsId = "",
            string itemBrandId = "",
            string itemDepartmentId = "",
            string keyword = "")
        {
            var conditions = "";
            if (!string.IsNullOrEmpty(status))
            {
                conditions += "AND `status` = @status ";
            }
            if (!string.IsNullOrEmpty(primarySupplierId))
            {
                conditions += "AND primary_supplier_id = @primarySupplierId ";
            }
            if (!string.IsNullOrEmpty(itemClsId))
            {
                conditions += "AND item_cls_id = @itemClsId ";
            }
            if (!string.IsNullOrEmpty(itemBrandId))
            {
                conditions += "AND item_brand_id = @itemBrandId ";
            }
            if (!string.IsNullOrEmpty(itemDepartmentId))
            {
                conditions += "AND item_department_id = @itemDepartmentId ";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                // TODO check keyword
                conditions += $"AND name LIKE '%{keyword}%' ";
            }

            var param = new
            {
                status,
                primarySupplierId,
                itemClsId,
                itemBrandId,
                itemDepartmentId
            };

            return GetPaging<ItemDTO>(pageIndex: pageIndex, pageSize: pageSize, conditions: conditions, param: param);
        }

        public bool CreateItem(Tuple<Item, List<ItemBarcode>, List<ItemPackage>, List<ItemSub>> itemInfo)
        {
            var item = itemInfo.Item1;
            var barcodes = itemInfo.Item2;
            var packages = itemInfo.Item3;
            var subs = itemInfo.Item4;

            return Run(conn =>
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        conn.Insert<Item>(item, transaction);
                        foreach (var barcode in barcodes)
                        {
                            conn.Insert<ItemBarcode>(barcode, transaction);
                        }
                        foreach (var package in packages)
                        {
                            conn.Insert<ItemPackage>(package, transaction);
                        }
                        foreach (var sub in subs)
                        {
                            conn.Insert<ItemSub>(sub, transaction);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    transaction.Commit();
                    return true;
                }
            });
        }

        public bool UpdateItem(Tuple<Item, List<ItemBarcode>, List<ItemPackage>, List<ItemSub>> itemInfo)
        {
            var item = itemInfo.Item1;
            var barcodes = itemInfo.Item2;
            var packages = itemInfo.Item3;
            var subs = itemInfo.Item4;

            var dbBarcodes = _itemBarcodeDao.GetItemBarcodesByItemId(item.Id);
            var dbPackages = _itemPackageDao.GetItemPackagesByItemId(item.Id);
            var dbSubs = _itemSubDao.GetItemSubsByItemId(item.Id);

            return Run(conn =>
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Item
                        conn.Update<Item>(item, transaction);

                        // Barcodes
                        foreach (var barcode in barcodes)
                        {
                            if (dbBarcodes.Exists(b => b.Id == barcode.Id))
                            {
                                conn.Update(barcode, transaction);
                            }
                            else
                            {
                                conn.Insert(barcode, transaction);
                            }
                        }
                        foreach (var dbBarcode in dbBarcodes)
                        {
                            if (!barcodes.Exists(b => b.Id == dbBarcode.Id))
                            {
                                conn.Delete(new ItemBarcode() { Id = dbBarcode.Id });
                            }
                        }

                        // Packages
                        foreach (var package in packages)
                        {
                            if (dbPackages.Exists(b => b.Id == package.Id))
                            {
                                conn.Update(package, transaction);
                            }
                            else
                            {
                                conn.Insert(package, transaction);
                            }
                        }
                        foreach (var dbPackage in dbPackages)
                        {
                            if (!packages.Exists(b => b.Id == dbPackage.Id))
                            {
                                conn.Delete(new ItemPackage() { Id = dbPackage.Id });
                            }
                        }

                        // Subs
                        foreach (var sub in subs)
                        {
                            if (dbSubs.Exists(b => b.Id == sub.Id))
                            {
                                conn.Update(sub, transaction);
                            }
                            else
                            {
                                conn.Insert(sub, transaction);
                            }
                        }
                        foreach (var dbSub in dbSubs)
                        {
                            if (!subs.Exists(b => b.Id == dbSub.Id))
                            {
                                conn.Delete(new ItemSub() { Id = dbSub.Id });
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    transaction.Commit();
                    return true;
                }
            });

            throw new NotImplementedException();
        }
    }
}