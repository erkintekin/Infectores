using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Throw
    {
        [Key]
        public int ThrowID { get; set; }
        public string Modifier { get; set; }
        public int Value { get; set; } // It must not be a hard code!

    }
}