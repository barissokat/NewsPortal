using Autofac;
using Autofac.Integration.Mvc;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Classes
{
    public class BootStrapper
    {
        //Boot aşamasında çalışacak
        public static void RunConfig()
        {
            BuildAutoFac();
        }
        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NewsRepository>().As<INewsRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ImageRepository>().As<IImageRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Interface ler yazılacak core içindeki

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}