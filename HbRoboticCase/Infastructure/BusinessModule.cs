using HbRoboticCase.Commands;
using HbRoboticCase.Commands.Invoker;
using HbRoboticCase.Models;
using Ninject.Modules;

namespace HbRoboticCase.Infastructure
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArea>().To<Area>().InSingletonScope();
            Bind<ICommandMatcher>().To<CommandMatcher>().InSingletonScope();
            Bind<IMoveInvoker>().To<MoveInvoker>().InSingletonScope();
        }
    }
}