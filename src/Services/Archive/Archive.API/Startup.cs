using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Archive.API.Infrastructure;
using Archive.API.Infrastructure.AutofacModules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using FluentValidation.AspNetCore;
using Archive.API.Validator;
using AutoMapper;
using FluentValidation;
using System.Globalization;
using System.ComponentModel;

namespace Archive.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置对象
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomMVC(Configuration)
                .AddSwagger(Configuration)
                .AddCustomDbContext(Configuration)
                .AddAutoMapper(Assembly.GetEntryAssembly());
        }

        /// <summary>
        /// 配置DI容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
        }

        /// <summary>
        /// 配置中简件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 开发环境下开启开发人员异常页面
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 重定向HTTP为HTTPS
            app.UseHttpsRedirection();

            // Swagger
            app.UseSwagger(options => options.RouteTemplate = "{documentName}/swagger.json")
               .UseSwaggerUI(options => options.SwaggerEndpoint("/v1/swagger.json", "API V1"));

            // 路由中间件
            app.UseRouting();

            // 跨域中间件
            app.UseCors("CorsPolicy");

            // 身份认证中间件
            app.UseAuthorization();

            // 配置终结点
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", (context) =>
                {
                    return Task.Run(() =>
                    {
                        context.Response.WriteAsync("Archive Service Runing...");
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
            services.AddControllers()
                .AddFluentValidation(fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<ItemModelValidator>();
                    fv.ValidatorOptions.CascadeMode = CascadeMode.Continue;
                    fv.ValidatorOptions.LanguageManager.Culture = new CultureInfo("zh-CN");
                    fv.ValidatorOptions.DisplayNameResolver = (type, memberInfo, lambdaExpression) => {
                        var attr = memberInfo.GetCustomAttribute<DisplayNameAttribute>();
                        if(attr != null) {
                            return attr.DisplayName;
                        }else {
                            return memberInfo.Name.First().ToString().ToLower() + memberInfo.Name.Substring(1);
                        }
                    };
                    fv.ValidatorOptions.PropertyNameResolver = (type, memberInfo, lambdaExpression) => {
                        return memberInfo.Name.First().ToString().ToLower() + memberInfo.Name.Substring(1);
                    };
                })
                .AddNewtonsoftJson(option => {
                    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            
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
        /// 配置数据库上下文
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ArchiveContext>(options =>
                {
                    options.UseSqlServer(configuration["ConnectionString"],
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        });
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
                    Title = "Archive Service API",
                    Version = "v1",
                    Description = "Archive Service API"
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Archive.API.xml");
                options.IncludeXmlComments(filePath);
            });

            return services;
        }
    }
}
