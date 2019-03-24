using HbRoboticCase.Enums;

namespace HbRoboticCase.Commands
{
    public interface ICommandMatcher
    {
        CommandType GetCommandType(string command);
    }
}