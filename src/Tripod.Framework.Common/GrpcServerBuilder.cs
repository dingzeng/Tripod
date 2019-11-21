using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Grpc.Core;
using AutoMapper;
using System.Reflection;
using Grpc.Core.Logging;

namespace Tripod.Framework.Common
{
    public class GrpcServerBuilder
    {
        private ConfigurationOptions _configurationOptions;
        private IMapper _mapper;
        private ILogger _logger;    
        private List<ServerServiceDefinition> _serverServiceDefinitionList;
        private string _host = "localhost";
        private int _port;

        public GrpcServerBuilder()
        {
            this.BuildConfiguration();
            this.BuildMapper();
            this.SetLogger(new GrpcLogger());
            this._serverServiceDefinitionList = new List<ServerServiceDefinition>();
        }

        private void BuildMapper()
        {
            var mappingTypes = Assembly.GetEntryAssembly().GetTypes().Where(t => typeof(IMapping).IsAssignableFrom(t));
            var mapperConfiguration = new MapperConfiguration(cfg => 
            {
                foreach (var m in mappingTypes)
                {
                    var typeName = m.FullName;
                    var mapping = (IMapping)m.Assembly.CreateInstance(typeName);   
                    mapping.Configure(cfg);
                }
            });
            this._mapper = mapperConfiguration.CreateMapper();
        }

        private void BuildConfiguration()
        {
            // 获取配置信息
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            this._configurationOptions = new ConfigurationOptions() {
                ConnectionString = configuration["connectionString"]
            };
        }

        public GrpcServerBuilder AddService(Func<ConfigurationOptions,IMapper,ServerServiceDefinition> func)
        {
            var definition = func(this._configurationOptions,this._mapper);
            this._serverServiceDefinitionList.Add(definition);
            return this;
        }

        public GrpcServerBuilder UsePort(int port)
        {
            this._port = port;
            return this;
        }

        public GrpcServerBuilder UseHost(string host)
        {
            this._host = host;
            return this;
        }

        public GrpcServerBuilder SetLogger(ILogger logger)
        {
            this._logger = logger;
            return this;
        }

        public void Start()
        {
            GrpcEnvironment.SetLogger(this._logger);

            Server server = new Server
            {
                Ports = { new ServerPort(this._host, this._port, ServerCredentials.Insecure) }
            };

            foreach (var service in this._serverServiceDefinitionList)
            {
                server.Services.Add(service);
            }

            server.Start();

            Console.WriteLine("服务监听端口： " + this._port);
            Console.WriteLine("任意键退出...");
            Console.Read();

            server.ShutdownAsync().Wait();
        }
    }
}