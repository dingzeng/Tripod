using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.Stock.DAL;
using Tripod.Service.Stock.Model;
using Tripod.Framework.Common;
using AutoMapper;

namespace Tripod.Service.Stock.Services
{
    public class ItemStockService : ItemStockSrv.ItemStockSrvBase
    {
        public ItemStockService(IMapper mapper, ConfigurationOptions options)
        {
        }
    }
}