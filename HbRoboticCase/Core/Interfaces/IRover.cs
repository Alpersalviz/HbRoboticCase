using HbRoboticCase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HbRoboticCase.Core.Interfaces
{
    public interface IRover
    {
       Position Move(char[] moves,IArea area);
    }
}
