using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ThrowDTO
    {
        public int ThrowID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string AbilityType { get; set; }

        public int BaseDC { get; set; }
    }
}