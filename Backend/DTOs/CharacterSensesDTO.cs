using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CharacterSensesDTO
    {
        public int CharacterID { get; set; }
        public int SenseID { get; set; }
        public int Range { get; set; }
        public bool IsActive { get; set; }
    }
}