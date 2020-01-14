using Autofac;
using System;

namespace Building
{
    class Program
    {
        public static IContainer Container { get; set; }

        private static void Main(string[] args)
        {
            Container = InjectionConfig.BuildContainer();
            var application = Container.Resolve<Application>();

            application.Run();
        }
    }
}