using System;
using FishUp.Domain;

namespace FishUp.Identity.Infrastructure
{
    public class User : Entity
    {
        public string Username { get; private set; }
        public string NormalizedUsername { get; private set; }
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }
        public string PasswordHash { get; private set; }
        public string SecurityStamp { get; private set; }

        protected User() {}

        public User(string username, string email, string passwordHash, string securityStamp)
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
                throw new Exception("");

            if(Email is null)
                throw new Exception("");

            if(PasswordHash is null)
                throw new Exception("");
            
            if(SecurityStamp is null)
                throw new Exception("");
        }
    }
}