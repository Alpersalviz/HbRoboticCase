using HbRoboticCase.Core.Services;
using HbRoboticCase.Models;
using System; 
namespace HbRoboticCase.Commands
{
    public class MoveCommand : ICommand
    {
        private Rover _rover;
        private char[] _moves { get; set; }
        private IArea _area {get; set;}
        public MoveCommand(char[] moves,Position position)
        { 
            _moves = moves;
            _rover = new Rover(position);
        }
        public void Execute()
        {
           Position position = _rover.Move(_moves,_area);  
           Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");

        }  
        public void SetAttributes(IArea area)
        {
            _area = area; 
        }  
    }
}
