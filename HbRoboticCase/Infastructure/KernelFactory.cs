using System.Reflection;
using Ninject;

namespace HbRoboticCase.Infastructure
{
    public class KernelFactory
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
