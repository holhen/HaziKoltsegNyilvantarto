using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace HáziKöltségNyilvántartó
{
    static class Program
    {
        public static IContainer Container;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SampleContext>().As<ISampleContext>().InstancePerLifetimeScope();
            builder.RegisterType<KoltsegvetesFelvitele>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TermekekFelvitele>().AsSelf().InstancePerLifetimeScope();
            Container = builder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<TermekekFelvitele>());
        }
    }
}
