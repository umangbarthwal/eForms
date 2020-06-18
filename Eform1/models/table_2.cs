using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
    public class table_2
    {

        // public int DUM { get; set; }

        //[ForeignKey("table_1")]

        [ForeignKey("table_1")]
        public int UID_F1 { get; set; }

        [Key]
        [Required]
        public int UID_Q { get; set; }

        public string Question_Type { get; set; }

        public string Question { get; set; }

        #region Navigation Properties
        public table_1 table_1 { get; set; }
        public ICollection<table_3> table_3 { get; set; }
        #endregion

        // public table_1 table_1 { get; set; }
        //public table_3 table_3 { get; set; }  [ForeignKey("table_3")]
    }
}

