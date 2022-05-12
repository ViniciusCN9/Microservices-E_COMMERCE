using System;
using Access.shared.Entities;
using Access.shared.Enums;

namespace Access.domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public ERole Role { get; private set; } = ERole.CUSTOMER;
    }
}