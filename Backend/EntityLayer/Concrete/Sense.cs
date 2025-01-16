using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Sense
    {
        [Key]
        public int SenseID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}