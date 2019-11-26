using System;
using Tripod.Framework.Common;
using Tripod.Service.Stock.Services;

namespace Tripod.Service.Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            new GrpcServerBuilder()
                .UseHost("0.0.0.0")
                .UsePort(8053)
                .AddService((options,mapper) => ItemStockSrv.BindService(new ItemStockService(mapper, options)))
                .Start();
        }
    }
}
