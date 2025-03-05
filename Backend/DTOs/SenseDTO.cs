using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class SenseDTO
    {
        public int SenseID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Range { get; set; }

        public bool RequiresLight { get; set; }
    }
}