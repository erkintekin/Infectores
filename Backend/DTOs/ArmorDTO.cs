using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ArmorDTO
    {
        public int ArmorID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        public int ArmorClass { get; set; }

        [Required]
        public required string ArmorType { get; set; }
        public float Weight { get; set; }
        public float Cost { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
        public int BaseAC { get; set; }
        public int DexterityModifier { get; set; }
    }

    public class ArmorCreateDTO
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        public int ArmorClass { get; set; }
        public int ArmorTypeID { get; set; }
        public float Weight { get; set; }
        public float Cost { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
        public int BaseAC { get; set; }
        public int DexterityModifier { get; set; }
    }

    public class ArmorUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        public int ArmorClass { get; set; }
        public int ArmorTypeID { get; set; }
        public float Weight { get; set; }
        public float Cost { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
        public int BaseAC { get; set; }
        public int DexterityModifier { get; set; }
    }
}