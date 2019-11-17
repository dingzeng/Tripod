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
        /// 删除机构组下的机构关系
        /// </summary>
        /// <param name="branchGroupId">机构组id</param>
        /// <param name="branchIdList">机构id列表</param>
        /// <returns></returns>
        public bool DeleteBranchGroupBranchs(int branchGroupId, IList<string> branchIdList)
        {
            if (branchIdList == null || branchIdList.Count == 0)
            {
                throw new ArgumentNullException(nameof(branchIdList));
            }

            var ids = string.Join(",", branchIdList.Select(id => $"'{id}'"));
            var sql = $"DELETE FROM branch_group_branch WHERE branch_group_id = @branchGroupId AND branch_id IN({ids});";

            return Run(conn =>
            {
                return conn.Execute(sql, new { branchGroupId = branchGroupId }) > 0;
            });
        }

        /// <summary>
        /// 添加机构组下的机构关系
        /// </summary>
        /// <param name="branchGroupId">机构组id</param>
        /// <param name="branchIdList">机构id列表</param>
        /// <returns></returns>
        public bool AddBranchGroupBranchs(int branchGroupId, IList<string> branchIdList)
        {
            if (branchIdList == null || branchIdList.Count == 0)
            {
                throw new ArgumentNullException(nameof(branchIdList));
            }

            return Run(conn =>
            {
                var existsBranchIdList = conn.Query<string>("SELECT branch_id FROM branch_group_branch WHERE branch_group_id = @branchGroupId;", new { branchGroupId = branchGroupId }).ToList();
                var targetIdList = branchIdList.Except(branchIdList.Intersect(existsBranchIdList));
                if (targetIdList.Count() == 0)
                {
                    // 要添加的机构在该机构组中已存在
                    return false;
                }

                var values = string.Join(", ", targetIdList.Select(id => $"({branchGroupId}, '{id}')"));
                var sql = $"INSERT INTO branch_group_branch(branch_group_id, branch_id) VALUES {values};";

                return conn.Execute(sql) > 1;
            });
        }
    }
}