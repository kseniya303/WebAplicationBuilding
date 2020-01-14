using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum UnitEnum
    {
        [Display(Name = "Штука")]
        thing = 1,
        [Display(Name = "Тонна")]
        tonna = 2
    }
}
