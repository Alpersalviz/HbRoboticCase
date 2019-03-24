using HbRoboticCase.Enums;
using HbRoboticCase.Models;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace HbRoboticCase.Commands.Invoker
{
    public class MoveInvoker : IMoveInvoker
    {
        private ICommandMatcher _commandMatcher { get; set; }

        private readonly IDictionary<CommandType, Func<string, ICommand>> _commandParser;
        private List<Position> _positions { get; set; }
        private IArea _area { get; set; } 
        public MoveInvoker(ICommandMatcher commandMatcher , IArea area)
        {
            _commandMatcher = commandMatcher;
            _area = area;
            _positions = new List<Position>();
            _commandParser = new Dictionary<CommandType, Func<string, ICommand>>
            {
                 {CommandType.AreaCommand, ParseAreaCommand},
                 {CommandType.SetPositionCommand, ParseSetPositionCommand},
                 {CommandType.MoveCommand, ParseMoveCommand}
            };
        }

        public List<ICommand> InvokeAll(string commandString)
        {
            var commands = commandString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands.Select(x => _commandParser[_commandMatcher.GetCommandType(x)]
                    .Invoke(x)).ToList();
        }

        private ICommand ParseAreaCommand(string toParse)
        {
            var arguments = toParse.Split(' ');
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);
            var size = new Size(width, height); 
       
            var areaCommand = new AreaCommand(size , _area);
  
            return areaCommand;
        }

        private ICommand ParseSetPositionCommand(string toParse)
        {
            Position position = new Position(); 
            var arguments = toParse.Split(' '); 
            position.X = int.Parse(arguments[0]);
            position.Y = int.Parse(arguments[1]); 
            position.Direction = (Direction)Enum.Parse(typeof(Direction), arguments[2]);
            var setPositionCommand = new SetPositionCommand(position,_area);

            _positions.Add(position);
            return setPositionCommand;
        }

        private ICommand ParseMoveCommand(string toParse)
        {
            var arguments = toParse.ToCharArray(); 
            MoveCommand moveCommand = new MoveCommand(arguments,_positions.Last());
            moveCommand.SetAttributes(_area);
            return moveCommand;
        }
    }
}
