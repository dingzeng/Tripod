using System;
using Tripod.Framework.Common;
using Tripod.Service.Purchase.Services;

namespace Tripod.Service.Purchase
{
    class Program
    {
        static void Main(string[] args)
        {
            new GrpcServerBuilder()
                .UseHost("localhost")
                .UsePort(80052)
                .AddService((options,mapper) => PurchaseSrv.BindService(new PurchaseOrderService(mapper, options)))
                .Start();
        }
    }
}
