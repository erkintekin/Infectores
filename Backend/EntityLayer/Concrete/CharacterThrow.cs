using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterThrow
    {
        [Key]
        public int CharacterID { get; set; }
        public Character Character { get; set; }

        [Key]
        public int ThrowID { get; set; }
        public Throw Throw { get; set; }
        public int Value { get; set; }
    }
}