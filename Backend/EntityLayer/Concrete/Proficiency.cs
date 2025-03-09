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
        public required string Name { get; set; }
        public ICollection<Armor> Armors { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<ProficiencyTool> ProficiencyTools { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Language> Languages { get; set; }

        public Proficiency()
        {
            Armors = new List<Armor>();
            Weapons = new List<Weapon>();
            ProficiencyTools = new List<ProficiencyTool>();
            Classes = new List<Class>();
            Languages = new List<Language>();
        }
    }
}