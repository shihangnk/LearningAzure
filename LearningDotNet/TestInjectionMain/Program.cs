using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using TestInjectionLib_CSharp;

namespace TestInjectionMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var king = container.Resolve<IMap>();

            // work
            Class1 obj = new Class1();
            obj.Fun();

            container.Dispose();
        }

        private void init()
        {

        }

        public void fun()
        {

        }
    }
}
