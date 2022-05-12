using Access.domain.Interfaces;

namespace Access.domain.Queries
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}