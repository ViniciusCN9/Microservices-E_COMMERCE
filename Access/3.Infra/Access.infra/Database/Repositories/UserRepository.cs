using System.Linq;
using Access.domain.Entities;
using Access.domain.Interfaces;
using Access.infra.Database.Context;

namespace Access.infra.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User FindUser(string username)
        {
            User user;
            try
            {
                user = _context.Users.FirstOrDefault(e => e.Username == username);
            }
            catch
            {
                user = null;
            }

            return user;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}