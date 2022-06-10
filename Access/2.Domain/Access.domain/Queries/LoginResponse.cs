using Access.domain.Interfaces;
using Access.shared.Enums;

namespace Access.domain.Queries
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public ERole Role { get; set; }
        public string Token { get; set; }
    }
}