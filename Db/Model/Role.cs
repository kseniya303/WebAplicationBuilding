using Common.Enums;
using Common.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Model
{
    public class Role
    {
        public Role() { }

        private Role(RoleEnum @enum)
        {
            Id = @enum;
            Name = @enum.GetEnumText();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RoleEnum Id { get; set; } 
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public static implicit operator Role(RoleEnum @enum) => new Role(@enum);
    }
}
