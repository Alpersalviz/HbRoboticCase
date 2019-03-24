using HbRoboticCase.Core.Services;
using HbRoboticCase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HbRoboticCase.Commands
{
    public class SetPositionCommand : ICommand
    {
        private Rover _rover;
        private Position _position { get; set; } 
        private IArea _area { get; set; }

        public SetPositionCommand(Position position , IArea area)
        {
            _area = area;
            _position = position;
            _rover = new Rover(position); 
        }
        public void Execute()
        {
            _rover.SetPosition(_position,_area);
        }
    }
}
