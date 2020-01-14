using BLL.Interfaces;
using Db.Model;
using Repository.Interfaces;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Contains logic to work witk User instance
    /// </summary>
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public User Create(User user)
        {
            return userRepository.Create(user);
        }

        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }
  
        public User Read(int id)
        {
            return userRepository.Read(id);
        }

        public IQueryable<User> ReadAll()
        {
            return userRepository.ReadAll();
        }

        public User Update(User user)
        {
            return userRepository.Update(user);
        }
    }
}
