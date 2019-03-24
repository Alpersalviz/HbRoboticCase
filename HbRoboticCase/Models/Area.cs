namespace HbRoboticCase.Models
{
    public class Area : IArea
    {
        private Size _size { get; set; }
        public Size GetSize()
        {
            return _size;
        }

        public void SetSize(Size size)
        {
            _size = size;
        }

        public bool IsValid(Position position)
        {
            bool isValidX = position.X >= 0 && position.X <= _size.Width;
            bool isValidY = position.Y >= 0 && position.Y <= _size.Height;
            return isValidX && isValidY;

        } 
    }  
}
