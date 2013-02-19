using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Web.Data.Concrete;
using Web.Data.Interface;

namespace Web.Infrastructure.DependencyInjection.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(MongoWritableRepository<>)).As(typeof(IWritableRepository<>));
        }
    }
}