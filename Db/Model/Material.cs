using Common.Attributes;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Model
{
    public class Material
    {
        public Material()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public UnitEnum UnitId { get; set; }
        public float Num { get; set; }

        [UiManagerIgnore]
        public virtual Unit Unit { get; set; }

        [UiManagerIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
