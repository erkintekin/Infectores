using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CharacterProficiencyDTO
    {
        public int CharacterID { get; set; }
        public int ProficiencyID { get; set; }
        public bool IsProficient { get; set; }
        public int BonusValue { get; set; }
    }
}