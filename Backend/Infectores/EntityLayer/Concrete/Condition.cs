using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Condition
    {
        [Key]
        public int ConditionID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? IsActive { get; set; } = false;
    }
}