using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class DamageType
    {
        [Key]
        public int DamageTypeID { get; set; }
        public string DamageType { get; set; }  // Bludgeoning, Piercing etc.
        public string? Description { get; set; }
    }
}