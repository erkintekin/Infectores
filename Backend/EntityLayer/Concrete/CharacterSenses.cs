using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterSenses
    {
        [Key]
        [Column(Order = 1)]
        public int CharacterID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SenseID { get; set; }

        public int Range { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("CharacterID")]
        public required Character Character { get; set; }

        [ForeignKey("SenseID")]
        public required Sense Sense { get; set; }
    }
}