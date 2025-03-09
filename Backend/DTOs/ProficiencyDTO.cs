using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ProficiencyDTO
    {
        public int ProficiencyID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public required ICollection<int> CharacterIds { get; init; }
        public required ICollection<int> ToolIds { get; init; }

        public ProficiencyDTO()
        {
            CharacterIds = new List<int>();
            ToolIds = new List<int>();
        }
    }
}