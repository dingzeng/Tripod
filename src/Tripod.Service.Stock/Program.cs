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
                .UseHost("localhost")
                .UsePort(80053)
                .AddService((options,mapper) => ItemStockSrv.BindService(new ItemStockService(mapper, options)))
                .Start();
        }
    }
}
