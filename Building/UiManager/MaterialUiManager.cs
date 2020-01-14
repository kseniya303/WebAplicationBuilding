using BLL.Interfaces;
using BLL.Services;
using Building.Menu;
using Common.Enums;
using Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Building.UiManager
{
    public class MaterialUiManager : UiManager
    {
        private IMaterialService materialService;
        private IUserService userService;

        public MaterialUiManager(IMaterialService _materialService, IUserService _userService)
        {
            materialService = _materialService;
            userService = _userService;
        }

        public override void Process(MenuItem menuItem)
        {
            Process(menuItem.Action.Value);
        }

        private void Process(ActionEnum action, string type = null)
        {
            switch (action)
            {
                case ActionEnum.Create:
                    var material = Read<Material>();
                    #region ex
                    //var userService 
                    //    = new UserService(new UserRepository(new BuildingContext()));

                    //var assembly = Assembly.LoadFile();
                    //var currentAssembly = Assembly.GetExecutingAssembly();
                    //var refAssemblies = currentAssembly.GetReferencedAssemblies();

                    //var bllAssemblyName = 
                    //    refAssemblies.FirstOrDefault
                    //    (assem => assem.Name == "BLL");

                    //var bllAssembly = Assembly.Load(bllAssemblyName);

                    //var userServiceType =
                    //    bllAssembly.GetType("BLL.Services.UserService");

                    //var userService = 
                    //    (UserService)Activator.CreateInstance(userServiceType);
                    #endregion
                    materialService.Create(material);
                    break;
                case ActionEnum.Read:
                    var materialRead = materialService.Read(int.Parse(type));
                    Write(materialRead);
                    break;
                case ActionEnum.ReadAll:
                    var materialReadAll = materialService.ReadAll();
                    WriteAll(materialReadAll);
                    Console.ReadKey();
                    break;
                //case ActionEnum.Take:
                //    var allUsers = userService.ReadAll();
                //    WriteAll<User>(allUsers);
                //    var readUserId = ReadId();
                //    List<User> listUser = new List<User>();
                //    foreach ( int id in readUserId)
                //    {
                //        listUser.Add(userService.Read(id));
                //    }

                //    var materialTake = Read<Material>();
                //    materialTake = materialService.Take(materialTake, listUser) ;
                //    Write(materialTake);
                //    Console.ReadKey();
                //    break;
            }
        }

        private List<int> ReadId()
        {
            return Console.ReadLine().Split(',').Select(c=>Int32.Parse(c)).ToList();
        }
    }
}
