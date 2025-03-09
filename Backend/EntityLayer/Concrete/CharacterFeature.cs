using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterFeature
    {
        [Key]
        [Column(Order = 1)]
        public int CharacterID { get; set; }
        public required Character Character { get; set; }
        [Key]
        [Column(Order = 2)]
        public int FeatureID { get; set; }
        public required Feature Feature { get; set; }
    }
}