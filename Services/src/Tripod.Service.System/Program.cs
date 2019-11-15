using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Tripod.Framework.Common;

namespace Tripod.Service.System
{
    class Program
    {
        static void Main(string[] args)
        {
            new GrpcServerBuilder()
                .UseHost("localhost")
                .UsePort(80054)
                .AddService((options,mapper) => SystemSrv.BindService(new SystemService(mapper, options)))
                .Start();
        }
    }
}
