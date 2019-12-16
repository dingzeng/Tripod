using System;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Tripod.Framework.Common;
using Tripod.Framework.Common.DAL;
using Tripod.Service.Archive.Model;

namespace Tripod.Service.Archive.DAL
{
    public class BranchGroupDAO : BaseDAO<BranchGroup>
    {
        public BranchGroupDAO(ConfigurationOptions options)
            : base(options.ConnectionString)
        {
        }
        
        /// <summary>
        /// 修改店组机构
        /// </summary>
        /// <param name="branchGroupId"></param>
        /// <param name="branchIdList"></param>
        /// <returns></returns>
        public bool UpdateBranchGroupBranchs(int branchGroupId, IList<string> branchIdList)
        {
            int lines = 0;
            return Run(conn =>
            {
                var sql = $"DELETE FROM branch_group_branch WHERE branch_group_id = @branchGroupId;";
                lines += conn.Execute(sql, new { branchGroupId = branchGroupId });

                if (branchIdList != null && branchIdList.Count > 0)
                {
                    var values = string.Join(", ", branchIdList.Select(id => $"({branchGroupId}, '{id}')"));
                    sql = $"INSERT INTO branch_group_branch(branch_group_id, branch_id) VALUES {values};";
                    lines += conn.Execute(sql);
                }
                return lines > 0;
            });
        }

        public PagedList<BranchGroup> GetBranchGroups(
            int pageIndex = 1,
            int pageSize = int.MaxValue,
            string keyword = null)
        {
            string conditions = "";
            if (!string.IsNullOrEmpty(keyword))
            {
                conditions += $"AND (id LIKE '%{keyword}%' OR name LIKE '%{keyword}%') ";
            }

            return this.GetPaging<BranchGroup>(
                pageIndex: pageIndex,
                pageSize: pageSize,
                conditions: conditions);
        }
    }
}