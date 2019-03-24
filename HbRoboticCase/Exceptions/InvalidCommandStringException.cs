using System;
using System.Collections.Generic;
using System.Text;

namespace HbRoboticCase.Exceptions
{
    public class InvalidCommandStringException : Exception
    {
        public InvalidCommandStringException(string message , Exception e) 
            : base(message,e)
        {
            
        }
    }
}
