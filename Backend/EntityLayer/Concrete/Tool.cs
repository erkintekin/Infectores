using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Tool
    {
        [Key]
        public int ToolID { get; set; }
        public required string Name { get; set; }
        public ICollection<ProficiencyTool> ProficiencyTools { get; set; }

        public Tool()
        {
            ProficiencyTools = new List<ProficiencyTool>();
        }
    }
}