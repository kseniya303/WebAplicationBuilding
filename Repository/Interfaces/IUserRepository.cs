using Db.Model;
using System.Linq;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        //User Login(string name, string password);
        User Create(User user);
        User Read(int id);
        IQueryable<User> ReadAll();
        User Update(User user);
        bool Delete(int id);
    }
}
