using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Tripod.Service.Archive.DAL;
using Tripod.Service.Archive.Model;
using Tripod.Framework.Common;
using AutoMapper;

namespace Tripod.Service.Archive.Services
{
    public class SupplierService : SupplierSrv.SupplierSrvBase
    {
        public SupplierService(IMapper mapper, ConfigurationOptions options)
        {
        }
    }
}