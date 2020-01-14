using Db.Model;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        //User Login(string name, string password);
        User Create(User user);
        User Read(int id);
        IQueryable<User> ReadAll();
        User Update(User user);
        bool Delete(int id);
    }
}
