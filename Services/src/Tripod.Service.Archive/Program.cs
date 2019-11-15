using System;
using Tripod.Framework.Common;
using Tripod.Service.Archive.Services;

namespace Tripod.Service.Archive
{
    class Program
    {
        static void Main(string[] args)
        {
            new GrpcServerBuilder()
                .UseHost("localhost")
                .UsePort(80051)
                .AddService((options,mapper) => ItemSrv.BindService(new BranchService(mapper, options)))
                .AddService((options,mapper) => ItemSrv.BindService(new ItemService(mapper, options)))
                .AddService((options,mapper) => ItemSrv.BindService(new PriceService(mapper, options)))
                .AddService((options,mapper) => ItemSrv.BindService(new SupplierService(mapper, options)))
                .Start();
        }
    }
}
