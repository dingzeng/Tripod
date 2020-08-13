using Archive.API.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tripod.Core;

namespace Archive.API.Infrastructure
{
    public class ArchiveContextSeed
    {
        public void Seed(ArchiveContext context)
        {
            using (context)
            {
                foreach (var branch in GetBranches())
                {
                    if (!context.Branches.Any(b => b.Id == branch.Id))
                    {
                        context.Branches.Add(branch);
                    }
                }
                context.SaveChanges();
            }
        }

        private IEnumerable<Branch> GetBranches()
        {
            yield return new Branch()
            {
                Id = "00",
                ParentId = "",
                Name = "总部",
                ShortName = "总部",
                Type = BranchType.Headquarters,
                ContactsName = "曾总",
                ContactsMobile = "15871369831",
                ContactsTel = "027-8820520",
                ContactsEmail = "1090211579@qq.com",
                Address = "江夏区百步亭江南郡",
                Memo = "种子数据"
            };
        }
    }
}
