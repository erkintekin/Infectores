using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ProficiencyToolDTO
    {
        public int ProficiencyID { get; set; }
        public int ToolID { get; set; }
        public required string ProficiencyName { get; set; }
        public required string ToolName { get; set; }
    }
}