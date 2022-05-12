using Access.domain.Entities;

namespace Access.domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}