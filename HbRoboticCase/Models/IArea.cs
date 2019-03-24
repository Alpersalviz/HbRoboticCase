namespace HbRoboticCase.Models
{
    public interface IArea
    {
        Size GetSize();
        void SetSize(Size size);
        bool IsValid(Position position);
    }
}