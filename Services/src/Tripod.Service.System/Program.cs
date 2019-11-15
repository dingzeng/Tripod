using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Tripod.Framework.Common;
using Tripod.Service.System.Mapping;

namespace Tripod.Service.System
{
    class Program
    {
        static void Main(string[] args)
        {
            // 获取配置信息
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var options = new ConfigurationOptions() {
                ConnectionString = configuration["connectionString"]
            };

            // 设置Grpc日志处理器
            GrpcEnvironment.SetLogger(new GrpcLogger());

            // 动态配置对象映射
            var mappingTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IMapping).IsAssignableFrom(t));
            var mapperConfiguration = new MapperConfiguration(cfg => 
            {
                foreach (var m in mappingTypes)
                {
                    var typeName = m.FullName;
                    var mapping = (IMapping)m.Assembly.CreateInstance(typeName);   
                    mapping.Configure(cfg);
                }
            });
            var mapper = mapperConfiguration.CreateMapper();

            // Server
            const int Port = 50054;
            Server server = new Server
            {
                Services = { SystemSrv.BindService(new SystemService(mapper, options)) },
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
