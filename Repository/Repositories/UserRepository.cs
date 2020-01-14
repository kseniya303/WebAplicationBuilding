using Db;
using Db.Model;
using Repository.Interfaces;
using System.Configuration;
using System.Linq;

namespace Repository.Repositories
{
    /// <summary>
    /// Contains logic to work with User table
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private BuildingContext context;

        public UserRepository(BuildingContext _context)
        {
            context = _context;
        }

        public User Create(User user)
        {
            var result = context.Users.Add(user);
            context.SaveChanges();
            return result;
        }

        public bool Delete(int id)
        {
            var user = context.Users.Find(id);
            user.IsDeleted = true;
            context.SaveChanges();
            return user.IsDeleted;
        }

        public User Read(int id)
        {
            var result = context.Users.Find(id);
            return result;
        }

        public User Update(User user)
        {
            var userToUpdate = context.Users.Find(user.Id);
            userToUpdate.Name = user.Name;
            context.SaveChanges();
            return userToUpdate;
        }

        public IQueryable<User> ReadAll()
        {
            return context.Users;
        }
         
    }
}
