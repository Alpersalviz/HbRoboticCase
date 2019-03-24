using HbRoboticCase.Enums;

namespace HbRoboticCase.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; } 
        public Position()
        {
            X = Y = 0;
            Direction = Direction.N;
        }
    }
}
