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
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System.IO;
    using System.Net.Http;
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
            services.AddScoped(provider =>
            {
                var httpClientHandler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
                var httpClient = new HttpClient(httpClientHandler);
                var address = Configuration.GetSection("GrpcAddress")["SystemService"];
                var grpcOptions = new GrpcChannelOptions() { HttpClient = httpClient };
                GrpcChannel channel = GrpcChannel.ForAddress(address, grpcOptions);
                return new UserGrpc.UserGrpcClient(channel);
            });

            services
                .AddCustomMVC(Configuration)
                .AddSwagger(Configuration)
                .AddCustomIdentity(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             // Swagger
            app.UseSwagger(options => options.RouteTemplate = "{documentName}/swagger.json")
               .UseSwaggerUI(options => options.SwaggerEndpoint("/v1/swagger.json", "API V1"));

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", (context) =>
                {
                    return Task.Run(() =>
                    {
                        context.Response.WriteAsync("Identity Service Runing...");
                    });
                });
            });
        }
    }

    /// <summary>
    /// 自定义扩展
    /// </summary>
    public static class CustomExtensionMethods
    {
        /// <summary>
        /// 配置MVC服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomMVC(this IServiceCollection services, IConfiguration configuration)
        {
            // 添加MVC控制器服务
            services.AddControllers();
            
            // 添加跨域服务
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }
        
        /// <summary>
        /// 配置Swagger服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Identity Service API",
                    Version = "v1",
                    Description = "Identity Service API"
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Identity.API.xml");
                options.IncludeXmlComments(filePath);
            });

            return services;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var secrityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["IdentitySecurityKey"]));
            services.AddSingleton(secrityKey);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => { })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromSeconds(30),
                        ValidateIssuerSigningKey = true,
                        ValidAudience = "localhost",
                        ValidIssuer = "localhost",
                        IssuerSigningKey = secrityKey
                    };
                });
            return services;
        }
    }
}
