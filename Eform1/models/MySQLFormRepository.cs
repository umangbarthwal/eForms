using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
    public class MySQLFormRepository : IFormRepository
    {
        private FormDbContext context;
        

        public MySQLFormRepository(FormDbContext Context)
        {
            this.context = Context;
            

        }
        void IFormRepository.Add_1(table_1 Table_1)
        {
            context.table_1s.Add(Table_1);
            context.SaveChanges();
        }

        void IFormRepository.Add_2(table_2 Table_2)
        {
            context.table_2s.Add(Table_2);
            context.SaveChanges();
            context.Entry(Table_2).State = EntityState.Detached;
        }

        void IFormRepository.Add_3(table_3 Table_3)
        {
            context.table_3s.Add(Table_3);
            context.SaveChanges();
            context.Entry(Table_3).State = EntityState.Detached;

        }

        table_1 IFormRepository.GetAll1(int tem)
        {
            table_1 Table_1 = new table_1();
            return context.table_1s.Find(tem);
        }

        //async void IEnumerable<table_2> IFormRepository.GetAll2(int Id)
         IEnumerable<table_2> IFormRepository.GetAll2(int Id ) //IEnumerable<table_2>
        {
            //(await context.table_2s.Where(l => l.UID_F1 == Id).OrderBy(m => m.UID_Q).ToListAsync());
            //  throw new NotImplementedException();

            return context.table_2s.AsNoTracking().Where(l => l.UID_F1 == Id).OrderBy(m => m.UID_Q).ToList();


        }

         IEnumerable<table_3> IFormRepository.GetAll3(int tem)
        {
           
            return context.table_3s.AsNoTracking().Where(l => l.F2 == tem).OrderBy(m => m.UID_Q).OrderBy(n => n.ID_MCQ).ToList(); 
        }

        void IFormRepository.Remove_1(int Id)
        {
            table_1 Table_1 = context.table_1s.Find(Id);
            context.table_1s.Remove(Table_1);
            context.SaveChanges();
        }

        void IFormRepository.Remove_2(int Id)
        {
            // IEnumerable<table_2> List_2=context.table_2s.AsNoTracking().Where(l => l.UID_F1 == Id).OrderBy(m => m.UID_Q).ToList();
           // foreach(var Table_2 in List_2)
            {
                context.table_2s.RemoveRange(context.table_2s.Where( z => z.UID_F1 == Id));
                context.SaveChanges();

            }
            
        }

        void IFormRepository.Remove_3(int Id)
        {
            table_3 Table_3 = context.table_3s.Find(Id);
            context.table_3s.Remove(Table_3);
            context.SaveChanges();

        }

        void IFormRepository.Update_1(table_1 Table_1)
        {
            var table_update = context.table_1s.Attach(Table_1);
            table_update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }

        void IFormRepository.Update_2(table_2 Table_2)
        {
            var table_update = context.table_2s.Attach(Table_2);
            table_update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        void IFormRepository.Update_3(table_3 Table_3)
        {
            context.Attach(Table_3);
            context.Entry(Table_3).Property("Options").IsModified = true;
            context.SaveChanges();

            /*
            var table_update = context.table_3s.Attach(Table_3);
            table_update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            */

        }
        /* 
         *context.Entry(Table_3).State = EntityState.Added;
            this.context.table_3s.Add(Table_3);
            this.context.SaveChanges();
            

        context.Entry(Table_3).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

         
        
        Formdumy formdumy = context.forms.Find(Id);
context.forms.Remove(formdumy);
   context.SaveChanges();
public Employee Update(Employee emp)
{
   var employee = context.Employees.Attach(emp);
   employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
   context.SaveChanges();
   return emp;
}
*/
    }
}
