using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Tripod.Framework.Common;
using Tripod.Service.System.Services;

namespace Tripod.Service.System
{
    class Program
    {
        static void Main(string[] args)
        {
            new GrpcServerBuilder()
                .UseHost("0.0.0.0")
                .UsePort(8054)
                .AddService((options,mapper) => SystemSrv.BindService(new SystemService(mapper, options)))
                .Start();
        }
    }
}
