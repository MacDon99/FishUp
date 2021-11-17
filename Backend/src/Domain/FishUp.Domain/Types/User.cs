using System;

namespace FishUp.Domain.Types
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid IdentityUserId { get; set; }
        
        protected User() {}

        public User(string firstName, string lastName, Guid identityUserId, string secondName = null)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            IdentityUserId = identityUserId;
        }
        
        public override void Valid()
        {
            if(FirstName is null)
                throw new ServerException(ExceptionCode.CanNotBeNull, "FirstName cannot be null");

            if(LastName is null)
                throw new ServerException(ExceptionCode.CanNotBeNull, "LastName cannot be null");
        }
    }
}