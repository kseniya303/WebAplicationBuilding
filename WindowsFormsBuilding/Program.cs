using Autofac; 
using System; 
using System.Windows.Forms; 

namespace WindowsFormsBuilding
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Container = Injection.BContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<Form1>());
        }
        private static IContainer Container { get; set; }
    }
   
}
