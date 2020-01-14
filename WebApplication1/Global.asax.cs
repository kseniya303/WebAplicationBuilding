using Autofac;
using Autofac.Integration.Web;
using System; 
using System.Web;
using System.Web.Optimization;
using System.Web.Routing; 

namespace WebApplication1
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        void Application_Start(object sender, EventArgs e)
        {
            _containerProvider = new ContainerProvider(InjectionWeb.WebContainer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        static IContainerProvider _containerProvider; //инъекции
        
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

    }
}