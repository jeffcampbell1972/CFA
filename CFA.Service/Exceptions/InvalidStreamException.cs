using System;

namespace CFA.Service
{
    public class InvalidStreamException : Exception
    {
        public InvalidStreamException(string message) : base(message)
        {
        }
    }
    public static class InvalidStreamMessage
    {
        public static string MissingGroupStart = "Group does not begin with '{'";
        public static string MissingGroupEnding = "Group does not end with '}'";
        public static string MissingGarbageStart = "Garbage does not begin with '<'";
        public static string MissingGarbageEnding = "Garbage does not end with '>'.";
        public static string InvalidGroupCharacter = "Invalid character found in Group.";
    }
}
