using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace Purchase.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PurchaseContext>()
                .As<PurchaseContext>()
                .InstancePerLifetimeScope();
        }
    }
}
