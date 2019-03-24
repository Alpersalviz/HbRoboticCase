using HbRoboticCase.Core.Interfaces;
using HbRoboticCase.Enums;
using HbRoboticCase.Models;
using System;
using System.Collections.Generic;

namespace HbRoboticCase.Core.Services
{
    public class Rover : IRover
    { 
        private Position _position;  

        public IDictionary<Direction, Action> _rotateLeft;
        public IDictionary<Direction, Action> _rotateRight;
        public IDictionary<Direction, Action> _moveForward;
        public Rover(Position position)
        {
            _position = position; 
            _rotateLeft = new Dictionary<Direction, Action>
            {
                {Direction.N , () => _position.Direction = Direction.W },
                {Direction.W , () => _position.Direction = Direction.S },
                {Direction.S , () => _position.Direction = Direction.E },
                {Direction.E , () => _position.Direction = Direction.N }
            };

            _rotateRight = new Dictionary<Direction, Action>
            {
                {Direction.N , () => _position.Direction = Direction.E },
                {Direction.S , () => _position.Direction = Direction.W },
                {Direction.W , () => _position.Direction = Direction.N },
                {Direction.E , () => _position.Direction = Direction.S }
            };

            _moveForward = new Dictionary<Direction, Action>
            {
                {Direction.N , () =>  _position.Y += 1 },
                {Direction.S , () =>  _position.Y -= 1 },
                {Direction.W , () =>  _position.X -= 1 },
                {Direction.E , () =>  _position.X += 1 }
                };

        }
        public void SetPosition(Position position, IArea area)
        {
            if (!area.IsValid(position))
            {
                var size = area.GetSize();
                var exceptionMessage = string.Format("Deploy failed for point ({0},{1}). Plateau size is {2} x {3}.",
                    position.X, position.Y, size.Width, size.Height);
                throw new Exception(exceptionMessage);
            }

            _position.X = position.X;
            _position.Y = position.Y;
            _position.Direction = position.Direction; 
        }
        public Position Move(char[] moves , IArea area)
        { 
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':  
                        _moveForward[_position.Direction].Invoke();
                        break;
                    case 'L':
                        _rotateLeft[_position.Direction].Invoke();
                        break;
                    case 'R':
                       _rotateRight[_position.Direction].Invoke();
                        break;
                    default: 
                        throw new Exception($"Invalid Character {move}"); 
                }  
            }

            if (!area.IsValid(_position))
            {
             throw new Exception($"{_position.X},{_position.Y} is out of area");
            }  
            return _position;
        }
 
    }
}
