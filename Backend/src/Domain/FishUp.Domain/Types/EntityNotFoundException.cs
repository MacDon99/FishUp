namespace FishUp.Domain.Types
{
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException(ExceptionCode code) : base(code)
        {

        }
        public EntityNotFoundException(ExceptionCode code, string message) : base(code, message)
        {

        }
    }
}
