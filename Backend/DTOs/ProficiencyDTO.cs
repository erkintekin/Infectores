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
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<int> CharacterIds { get; set; }
        public ICollection<int> ToolIds { get; set; }
    }
}