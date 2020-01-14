using Autofac;
using BLL.Interfaces;
using BLL.Services;
using Building.UiManager;
using Db;
using Repository.Interfaces;
using Repository.Repositories;

namespace Building
{
    public static class InjectionConfig
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<Application>();
            builder.RegisterType<BuildingContext>()
                .SingleInstance();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();
            builder.RegisterType<MaterialRepository>()
                .As<IMaterialRepository>();

            builder.RegisterType<UserService>()
                .As<IUserService>();
            builder.RegisterType<MaterialService>()
                .As<IMaterialService>();

            builder.RegisterType<UserUiManager>();
            builder.RegisterType<MaterialUiManager>();

            
            return builder.Build();

        }
    }
}
