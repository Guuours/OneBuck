using System;

namespace OneBuck
{
    public class OneBuckException : Exception
    {
        public string Code { get; set; }

        public OneBuckException(string message, Exception innerException = null) : base(message, innerException) { }

        public OneBuckException(string code, string message, Exception innerException = null) : base(message, innerException)
        {
            Code = code;
        }
    }
}