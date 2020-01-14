using Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMaterialService
    {
        Material Create(Material material);
        Material Read(int id);// (string type);
        IQueryable<Material> ReadAll();// (string type); 
        Material Update(Material material);
    }
}
