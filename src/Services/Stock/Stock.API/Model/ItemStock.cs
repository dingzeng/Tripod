using System;
using System.Linq;
using System.Collections.Generic;
using Tripod.Core;

namespace Stock.API.Model
{
    public class ItemStock : Entity
    {
        public long Id { get; set; } 

        public long ItemId { get; set; }

        public string BranchId { get; set; }

        public int Qty { get; set; }
    }
}