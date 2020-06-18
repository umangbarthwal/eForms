using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
    public class Formdumy
    {
        
        //public int TEM { get; set; }
        //[Key]
        public int idforms { get; set; }
        public string FormName { get; set; }
        public string FormName1 { get; set; }
        public string radio { get; set; }
    }
}
