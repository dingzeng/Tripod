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
                Services = { Users.BindService(new UserService()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
