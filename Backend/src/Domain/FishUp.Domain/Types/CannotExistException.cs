namespace FishUp.Domain.Types
{
    public class CannotExistException : BaseException
    {
        public CannotExistException(ExceptionCode code) : base(code)
        {

        }
        public CannotExistException(ExceptionCode code, string message) : base(code, message)
        {

        }
    }
}
