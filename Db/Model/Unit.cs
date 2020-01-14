using Common.Enums;
using Common.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Model
{
    public class Unit
    {
        public Unit() { }

        private Unit(UnitEnum @enum)
        {
            Id = @enum;
            Name = @enum.GetEnumText();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public UnitEnum Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Material> Materials { get; set; }

        public static implicit operator Unit(UnitEnum @enum) => new Unit(@enum);
    }
}
