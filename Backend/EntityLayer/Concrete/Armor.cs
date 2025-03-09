using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Armor
    {
        [Key]
        public int ArmorID { get; set; }
        public required Item Item { get; set; }
        public int ArmorClass { get; set; }
        public int ArmorTypeID { get; set; }
        public required ArmorType ArmorType { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int? StrengthRequirement { get; set; }
        public int BaseAC { get; set; }
        public int? DexterityModifier { get; set; }
    }
}