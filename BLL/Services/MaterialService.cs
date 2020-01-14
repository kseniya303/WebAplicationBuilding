using BLL.Interfaces;
using Db.Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MaterialService : IMaterialService
    {
        private IMaterialRepository materialRepository;

        public MaterialService(IMaterialRepository _materialRepository)
        {
            materialRepository = _materialRepository;
        }
        
        public Material Create(Material material)
        {
            return materialRepository.Create(material);
        }

        public Material Read (int id)//(string type)
        {
            return materialRepository.Read(id);
            //var result = new Material()
            //{
            //    Name = type,
            //    Date = DateTime.Now,
            //    Unit = materialRepository
            //        .ReadAll()
            //        .FirstOrDefault(c => c.Name == type)
            //        .Unit,
            //    Num = materialRepository
            //        .ReadAll()
            //        .Where(c => c.Name == type)
            //        .Sum(s => s.Num)
            //};
            //return result; 
        }

        public IQueryable<Material> ReadAll()// (string type)
        {
            return materialRepository
                .ReadAll();
               // .Where(c => c.Name == type);
        }
        ////public Material Take(Material material, List<User> users)
        ////{
        ////    return null;
        ////    //var naSklade = Read(material.Name);
        ////    //if (material.Num > naSklade.Num)
        ////    //{
        ////    //    throw new Exception("Need more gold");
        ////    //}
        ////    //else
        ////    //{
        ////    //    var materialToAdd = new Material()
        ////    //    {
        ////    //        Date = DateTime.Now,
        ////    //        Name = material.Name,
        ////    //        Num = -material.Num,
        ////    //        UnitId = material.UnitId
        ////    //    };     
                
        ////    //    foreach (var user in users)
        ////    //    {
        ////    //        materialToAdd.Users.Add(user);
        ////    //    }
                
        ////    //    var result = Create(materialToAdd);
        
        ////    //    return result;
        ////    //}

        ////}

        public Material Update(Material material)
        {
            return materialRepository.Update(material);
        }
    }
}
