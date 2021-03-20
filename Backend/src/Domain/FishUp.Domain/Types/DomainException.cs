using System;

namespace FishUp.Domain.Types
{
    public class DomainException : ServerException
    {
        public DomainException(ExceptionCode code): base(code)
        {
            
        }
        public DomainException(ExceptionCode code, string message): base(code, message)
        {
            
        }
    }
}