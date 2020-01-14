using BLL.Interfaces;
using Building.Menu;
using Common.Enums;
using Db.Model;
using System;

namespace Building.UiManager
{
    public class UserUiManager : UiManager
    {
        private IUserService userService;

        public UserUiManager(IUserService _userService)
        {
            userService = _userService;
        }

        public override void Process(MenuItem menuItem)
        {
            Process(menuItem.Action.Value);
        }

        private void Process(ActionEnum action, int? userId = null)
        {
            switch (action)
            {
                case ActionEnum.Create:
                    var user = Read<User>();
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
                    userService.Create(user);
                    break;
                case ActionEnum.Read:
                    var userRead = userService.Read(userId.Value);
                    Write(userRead);
                    break;
                case ActionEnum.ReadAll:
                    var userReadAll = userService.ReadAll();
                    WriteAll(userReadAll);
                    Console.ReadKey();
                    break;
                case ActionEnum.Update:
                    break;
                case ActionEnum.Delete:
                    var userIdToDelete = ReadKey<User>();
                    var userReadToDelete = userService.Read(userIdToDelete);
                    if (userReadToDelete == null)
                        Console.WriteLine("No such User!");
                    else
                        userService.Delete(userIdToDelete);
                    break;
            }
        }

        
    }
}
