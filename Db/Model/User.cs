using Common.Attributes;
using Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Model
{
    /// <summary>
    /// Represents a person how have acces to the project
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[StringLength(50, MinimumLength = 3)] //подтянула NuGet пакет, на проверку ввода коректной инфы
        public string Name { get; set; }

        public string Password { get; set; } 

        [UiManagerIgnore]
        public bool IsDeleted { get; set; }

        public RoleEnum RoleId { get; set; }

        [UiManagerIgnore]
        public virtual Role Role { get; set; }

        [UiManagerIgnore]
        public virtual ICollection<Material> Materials { get; set; }
    }
}
