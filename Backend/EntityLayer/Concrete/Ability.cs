using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.EntityLayer.Concrete
{
    public class Ability
    {
        [Key]
        public int AbilityID { get; set; }
        public required string AbilityName { get; set; }
        public required string Value { get; set; }
        public string? Description { get; set; }
        public ICollection<CharacterAbility> CharacterAbilities { get; set; }
        public ICollection<Skill> Skills { get; set; }

        public Ability()
        {
            CharacterAbilities = new List<CharacterAbility>();
            Skills = new List<Skill>();
        }
    }
}