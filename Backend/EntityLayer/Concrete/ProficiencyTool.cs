using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class ProficiencyTool
    {
        [Key]
        [Column(Order = 1)]
        public int ProficiencyID { get; set; }
        public Proficiency Proficiency { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ToolID { get; set; }
        public Tool Tool { get; set; }
    }
}