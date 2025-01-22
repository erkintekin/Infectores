using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class ProficiencyTool
    {
        [Key]
        public int ProficiencyID { get; set; }
        public Proficiency Proficiency { get; set; }

        [Key]
        public int ToolID { get; set; }
        public Tool Tool { get; set; }
    }
}