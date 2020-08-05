using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity.API
{
    using Grpc.Net.Client;
    using GrpcSystem;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["IdentitySecurityKey"])));

            services.AddScoped(provider =>
            {
                GrpcChannel channel = GrpcChannel.ForAddress(Configuration.GetSection("GrpcAddress")["SystemService"]);
                return new UserGrpc.UserGrpcClient(channel);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", (context) =>
                {
                    return Task.Run(() =>
                    {
                        context.Response.WriteAsync("Runing...");
                    });
                });
            });
        }
    }
}
