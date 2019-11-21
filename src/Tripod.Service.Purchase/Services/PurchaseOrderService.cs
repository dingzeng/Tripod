using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.Purchase.DAL;
using Tripod.Service.Purchase.Model;
using Tripod.Framework.Common;
using AutoMapper;

namespace Tripod.Service.Purchase.Services
{
    public class PurchaseOrderService : PurchaseSrv.PurchaseSrvBase
    {
        public PurchaseOrderService(IMapper mapper, ConfigurationOptions options)
        {
        }
    }
}