using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CharacterThrowDTO
    {
        public int CharacterID { get; set; }
        public int ThrowID { get; set; }
        public bool IsProficient { get; set; }
        public int BonusValue { get; set; }
        public int SaveDC { get; set; }
    }
}