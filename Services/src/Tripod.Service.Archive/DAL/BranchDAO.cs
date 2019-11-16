using System;
using System.Linq;
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
    }
}