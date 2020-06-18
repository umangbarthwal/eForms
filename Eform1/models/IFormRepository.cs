using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
   public  interface IFormRepository
    {
        void Add_1(table_1 Table_1);
        void Add_2(table_2 Table_2);
        void Add_3(table_3 Table_3);

        void Remove_1(int Id);
        void Remove_2(int Id);
        void Remove_3(int Id);

        void Update_1(table_1 Table_1);
        void Update_2(table_2 Table_2);
        void Update_3(table_3 Table_3);

        table_1 GetAll1(int Id);
        public IEnumerable<table_2> GetAll2(int tem); //IEnumerable<table_2>
        public IEnumerable<table_3> GetAll3(int Id);
    }
}
