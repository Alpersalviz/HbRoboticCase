
using HbRoboticCase.Commands;
using HbRoboticCase.Commands.Invoker;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using HbRoboticCase.Infastructure;

namespace HbRoboticCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            Console.WriteLine(commandStringBuilder.ToString());

            var kernel = KernelFactory.CreateKernel();
            var  moveInvoker= kernel.Get<IMoveInvoker>();
            List<ICommand> commands = null;

            try
            { 
               commands = moveInvoker.InvokeAll(commandStringBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                Environment.Exit(0);
            }

            foreach (var item in commands)
            {
                try
                {
                    item.Execute();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
       
            Console.ReadLine();

        }
    }
}
