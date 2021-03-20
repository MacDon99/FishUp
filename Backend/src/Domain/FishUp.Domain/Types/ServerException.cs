using System;

namespace FishUp.Domain.Types
{
    public class ServerException : Exception
    {
        public ExceptionCode Code { get; }

        public ServerException(ExceptionCode code)
        {
            Code = code;
        }
        public ServerException(ExceptionCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}