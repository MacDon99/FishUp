using System;

namespace FishUp.Domain.Types
{
    public class DomainException : BaseException
    {
        public DomainException(ExceptionCode code): base(code)
        {
            
        }
        public DomainException(ExceptionCode code, string message): base(code, message)
        {
            
        }
    }
}