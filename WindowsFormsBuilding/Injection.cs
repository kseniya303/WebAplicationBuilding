using Autofac;
using BLL.Interfaces;
using BLL.Services;
using Db;
using Repository.Interfaces;
using Repository.Repositories;
using WindowsFormsBuilding.UserControls;

namespace WindowsFormsBuilding
{
    public static class Injection
    {
        public static IContainer BContainer()
        {
            var builder = new ContainerBuilder(); 

            builder.RegisterType<BuildingContext>()
               .SingleInstance();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>(); 

            builder.RegisterType<UserService>()
                .As<IUserService>();
            builder.RegisterType<ucUsers>();
            builder.RegisterType<Form1>();

            return builder.Build();
        }
    }
}
