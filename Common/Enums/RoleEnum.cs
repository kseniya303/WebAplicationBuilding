using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum RoleEnum
    {
        [Display(Name = "Worker")]
        Worker = 1,

        [Display(Name = "Manager")]
        Manager = 2
    }
}
