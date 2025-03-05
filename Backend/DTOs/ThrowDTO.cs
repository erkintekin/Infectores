using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ThrowDTO
    {
        public int ThrowID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string AbilityType { get; set; }

        public int BaseDC { get; set; }
    }
}