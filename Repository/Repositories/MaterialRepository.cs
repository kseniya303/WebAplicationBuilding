using System.Linq;
using Db;
using Db.Model;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private BuildingContext context;

        public MaterialRepository(BuildingContext _context)
        {
            context = _context;
        }

        public Material Create(Material material)
        {
            var result = context.Materials.Add(material);
            context.SaveChanges();
            return result;
        }

        public Material Read(int id)
        {
            var result = context.Materials.Find(id);
            return result;
        }

        public IQueryable<Material> ReadAll()
        {
            return context.Materials;
        }

        public Material Update(Material material)
        {
            var materialToUpdate = context.Materials.Find(material.Id);
            materialToUpdate.Name = material.Name;
            context.SaveChanges();
            return materialToUpdate;
        }
    }
}
