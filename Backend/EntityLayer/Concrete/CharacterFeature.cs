using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterFeature
    {
        [Key]
        public int CharacterFeatureID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int FeatureID { get; set; }
        public Feature Feature { get; set; }
    }
}