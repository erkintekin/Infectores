using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        public string Name { get; set; }
    }
}