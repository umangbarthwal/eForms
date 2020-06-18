using Eform1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.ViewModels
{
    public class FormModelView 
    {
        public table_1 Table_1;
        public IEnumerable<table_2> list_2 { get; set; }
        public IEnumerable<table_3> list_3 { get; set; }
    }
}
