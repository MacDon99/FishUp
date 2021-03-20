namespace FishUp.Domain.Types
{
    public class User : Entity
    {
        public string Username { get; private set; }
        public string NormalizedUsername { get; private set; }
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] SecurityStamp { get; private set; }

        protected User() {}

        public User(string username, string email, byte[] passwordHash, byte[] securityStamp)
        {
            Username = username;
            NormalizedUsername = username.ToUpper();
            Email = email;
            NormalizedEmail = email.ToUpper();
            PasswordHash = passwordHash;
            SecurityStamp = securityStamp;
        }
        
        public override void Valid()
        {
            if(Username is null)
                throw new ServerException(ExceptionCode.CanNotBeNull, "Username cannot be null");

            if(Email is null)
                throw new ServerException(ExceptionCode.CanNotBeNull, "Email cannot be null");

            if(PasswordHash is null)
                throw new ServerException(ExceptionCode.CanNotBeNull, "Password cannot be null");
            
            if(SecurityStamp is null)
                throw new ServerException(ExceptionCode.CanNotBeNull);
        }
    }
}