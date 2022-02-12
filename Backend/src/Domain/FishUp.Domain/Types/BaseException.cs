using System;

namespace FishUp.Domain.Types
{
    public abstract class BaseException : Exception
    {
        public ExceptionCode Code { get; }

        public BaseException(ExceptionCode code)
        {
            Code = code;
        }
        public BaseException(ExceptionCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}