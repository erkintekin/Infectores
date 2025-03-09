using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<CharacterFeature> CharacterFeatures { get; set; }

        public Feature()
        {
            CharacterFeatures = new List<CharacterFeature>();
        }
    }
}