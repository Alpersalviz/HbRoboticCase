using HbRoboticCase.Models; 

namespace HbRoboticCase.Commands
{
    public class AreaCommand : ICommand
    {
        private Size _size { get; set; }
        private IArea _area { get; set; }

        public AreaCommand(Size size , IArea area)
        {
            _area = area;
            _size = size;
        }
        public void Execute()
        {
            _area.SetSize(_size);
        } 
    }
}
