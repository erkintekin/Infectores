using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterSense
    {
        [Key]
        public int CharacterSensesID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int SenseID { get; set; }
        public Sense Sense { get; set; }
    }
}