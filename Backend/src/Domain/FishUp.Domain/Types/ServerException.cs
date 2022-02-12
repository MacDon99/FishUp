using System;

namespace FishUp.Domain.Types
{
    public class ServerException : BaseException
    {
        public ServerException(ExceptionCode code): base(code)
        {
            
        }
        public ServerException(ExceptionCode code, string message): base(code, message)
        {
            
        }
    }
}