namespace FishUp.Domain.Types
{
    public class ValidationException : BaseException
    {
        public ValidationException(ExceptionCode code): base(code)
        {
            
        }
        public ValidationException(ExceptionCode code, string message): base(code, message)
        {
            
        }
    }
}