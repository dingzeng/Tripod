using System;
using Grpc.Core;

namespace Tripod.Service.System
{
    class Program
    {
        static void Main(string[] args)
        { 
            const int Port = 50051;
            Server server = new Server
            {
                Services = { SystemSrv.BindService(new SystemService()) },
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
