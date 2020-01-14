using Autofac;
using BLL.Interfaces;
using BLL.Services;
using Db;
using Repository.Interfaces;
using Repository.Repositories;

namespace WebApplication1
{
    public static class InjectionWeb
    {
        public static IContainer WebContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BuildingContext>()
               .SingleInstance();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();

            builder.RegisterType<UserService>()
                .As<IUserService>();

            builder.RegisterType<MaterialRepository>()
                .As<IMaterialRepository>();

            builder.RegisterType<MaterialService>()
                .As < IMaterialService>();

            builder.RegisterType<About>();

            builder.RegisterType<Materials>();

            return builder.Build();
        }
    }
}