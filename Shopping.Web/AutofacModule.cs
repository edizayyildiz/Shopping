using Autofac;
using Shopping.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Shopping.Web
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Shopping.Service"))
                .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerDependency();
        }
    }
}
