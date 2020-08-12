using System;
using System.Linq;
using System.Collections.Generic;
using Tripod.Core;

namespace Stock.API.Model
{
    public class ItemBatchStock : Entity
    {
        public long Id { get; set; } 

        public long ItemId { get; set; }

        public string BranchId { get; set; }

        public string BatchNo { get; set; }

        public int Qty { get; set; }

        public decimal CostPrice { get; set; }

        public decimal CostAmount { get; set; }
    }
}