using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Proficiency
    {
        [Key]
        public int ProficiencyID { get; set; }
        public string Name { get; set; }
        public ICollection<Armor> Armors { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Tool> Tools { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Language> Languages { get; set; }
    }
}