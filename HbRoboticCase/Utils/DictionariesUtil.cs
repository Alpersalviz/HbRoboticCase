using HbRoboticCase.Enums; 
using System.Collections.Generic; 

namespace HbRoboticCase.Utils
{
    public static class DictionariesUtil
    { 

        public static Dictionary<string, CommandType> CommentTypeDictionary = new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.AreaCommand },
                { @"^\d+ \d+ [NSEW]$", CommandType.SetPositionCommand},
                { @"^[LRM]+$", CommandType.MoveCommand }
            };
    }
}
