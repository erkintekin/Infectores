using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ProficiencyToolDTO
    {
        public int ProficiencyID { get; set; }
        public int ToolID { get; set; }
        public string ProficiencyName { get; set; }
        public string ToolName { get; set; }
    }
}