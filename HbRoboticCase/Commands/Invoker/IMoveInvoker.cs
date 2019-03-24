using System.Collections.Generic;

namespace HbRoboticCase.Commands.Invoker
{
    public interface IMoveInvoker
    {
        List<ICommand> InvokeAll(string commandString);
    }
}
