using System;
using System.Collections.Generic;

namespace Tripod.Application.AdminApi.Model.BranchGroup
{
    public class UpdateBranchsModel
    {
        public int BranchGroupId { get; set; }

        public List<string> BranchIdList { get; set; }
    }
}