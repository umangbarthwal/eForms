using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
    public class table_1
    {
        [Key]
        public int UID_F { get; set; }
        public string Form_Name { get; set; }

        public string Creator { get; set; }
        public string Created_On { get; set; }



      //  public ICollection<table_2>  table_2{ get; set; }
    // public virtual table_2 Table_2 { get; set; } [ForeignKey("table_2")]
}
}
