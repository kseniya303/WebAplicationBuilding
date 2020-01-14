using Db.Model;
using System.Linq;

namespace Repository.Interfaces
{
    public interface IMaterialRepository
    {
        Material Create(Material material);
        Material Read(int id);
        Material Update(Material material);
        IQueryable<Material> ReadAll();
    }
}
