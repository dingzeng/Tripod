using System;
using System.IO;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Tripod.Framework.Common;

namespace Tripod.Service.System
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var options = new ConfigurationOptions() {
                ConnectionString = configuration["connectionString"]
            };

            GrpcEnvironment.SetLogger(new GrpcLogger());

            const int Port = 50054;
            Server server = new Server
            {
                Services = { SystemSrv.BindService(new SystemService(options)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("系统服务监听端口： " + Port);
            Console.WriteLine("任意键退出...");
            Console.Read();

            server.ShutdownAsync().Wait();
        }
    }
}
