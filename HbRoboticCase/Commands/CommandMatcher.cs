using HbRoboticCase.Enums;
using HbRoboticCase.Utils;
using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Text.RegularExpressions;
using HbRoboticCase.Exceptions;

namespace HbRoboticCase.Commands
{
    public class CommandMatcher : ICommandMatcher
    {
        private IDictionary<string, CommandType> _commandTypeDictionary;
        public CommandMatcher()
        {
            _commandTypeDictionary = DictionariesUtil.CommentTypeDictionary;
        } 
        public CommandType GetCommandType(string command)
        {
            try
            {
                var commandType = _commandTypeDictionary.First(
                    regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(command));
                
                return commandType.Value;
            }
            catch (InvalidOperationException e)
            { 
                var exceptionMessage = string.Format("String '{0}' is not a valid command", command);
                throw new InvalidCommandStringException(exceptionMessage,e);
            }
        } 
    }
}
