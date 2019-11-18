using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class BranchDAO : BaseDAO<Branch>
    {
        public BranchDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {

        }

        /// <summary>
        /// 获取机构组下的所有机构
        /// </summary>
        /// <param name="branchGroupId">机构组编码</param>
        /// <returns></returns>
        public List<Branch> GetBranchGroupBranchs(int branchGroupId)
        {
            var sql = @"
SELECT 
	a.*
FROM branch a
INNER JOIN branch_group_branch b ON a.id = b.branch_id
WHERE b.branch_group_id = @branchGroupId;";
            return Run(conn =>
            {
                return conn.Query<Branch>(sql, new { branchGroupId = branchGroupId }).ToList();
            });
        }

        /// <summary>
        /// 获取机构分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="keyword">搜索关键字：编码或名称</param>
        /// <param name="parentId">父级编码</param>
        /// <returns></returns>
        public PagedList<Branch> GetBranchs(
            int pageIndex = 1,
            int pageSize = int.MaxValue,
            string keyword = null,
            string parentId = null)
        {
            string inner = "SELECT * FROM branch";
            string conditions = "";
            if (!string.IsNullOrEmpty(keyword))
            {
                conditions += $"AND (id LIKE '%{keyword}%' OR name LIKE '%{keyword}%') ";
            }
            if (!string.IsNullOrEmpty(parentId))
            {
                conditions += $"AND parent_id = '{parentId}' ";
            }

            return this.GetPaging<Branch>(
                innerQuery: inner,
                pageIndex: pageIndex,
                pageSize: pageSize,
                conditions: conditions,
                param: new { });
        }

        /// <summary>
        /// 获取机构下的所有仓库
        /// </summary>
        /// <param name="branchId">机构id</param>
        /// <returns></returns>
        public IList<Store> GetStoresByBranchId(string branchId)
        {
            return Run(conn =>
            {
                return conn.Query<Store>("SELECT id, branch_id, name, is_usable FROM store WHERE branch_id = @branchId;", new { branchId = branchId }).ToList();
            });
        }
        
        /// <summary>
        /// 更新机构下的仓库
        /// </summary>
        /// <param name="branchId">机构id</param>
        /// <param name="stores">仓库列表</param>
        /// <returns></returns>
        public bool UpdateBranchStores(string branchId, List<Store> stores)
        {
            var values = string.Join(", ", stores.Select(s => $"((@branchId, '{s.Name}', {s.IsUsable}))"));
            StringBuilder builder = new StringBuilder();
            builder.Append("DELETE FROM store WHERE branch_id = @branchId;");
            builder.Append($"INSERT INTO store(branch_id, `name`, is_usable) VALUES{values};");

            return Run(conn =>
            {
                return conn.Execute(builder.ToString(), new { branchId = branchId }) > 0;
            });
            throw new NotImplementedException();
        }
    }
}