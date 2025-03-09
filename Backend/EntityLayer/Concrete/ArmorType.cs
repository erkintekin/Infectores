using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.EntityLayer.Concrete
{
    public class ArmorType
    {
        [Key]
        public int ArmorTypeID { get; set; }
        public required string Type { get; set; }
        public ICollection<Armor> Armors { get; set; }

        public ArmorType()
        {
            Armors = new List<Armor>();
        }
    }
}