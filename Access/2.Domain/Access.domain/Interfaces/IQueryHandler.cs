using Access.domain.Queries;

namespace Access.domain.Interfaces
{
    public interface IQueryHandler
    {
        LoginResponse Handle(LoginRequest query);
    }
}