using Access.domain.Interfaces;

namespace Access.domain.Commands
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}