using Access.domain.Entities;

namespace Access.domain.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string query);
        void CreateUser(User command);
    }
}