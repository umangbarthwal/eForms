using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Eform1.models;
using Eform1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Eform1.Data;

namespace Eform1.controllers
{
    public class HomeController : Controller
    {
        public IFormRepository _formRepository;
        public readonly FormDbContext _db;

        public HomeController(IFormRepository formRepository, FormDbContext db)
        {
            _formRepository = formRepository;
            _db = db;
        }




        public async Task<IActionResult> Index()
        {
           // _formRepository.Remove_2(279432155);

            /*table_3 Table_3 = new table_3();
            Table_3.F2 = 279432155;
            Table_3.ID_MCQ = 1;
            Table_3.UID_Q = 0;
            Table_3.Options = "yoyo";
            _formRepository.Update_3(Table_3);
            */
            return View(await _db.table_1s.OrderBy(s => s.UID_F).ToListAsync());
        }



        [HttpGet]
        public ViewResult CreateForm()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateForm([Bind("UID_F,Form_Name,Creator,Created_On")] table_1 Table_1,
                                        [Bind("UID_F1,UID_Q,Question_Type,Question")] table_2 Table_2,
                                        [Bind("F2,UID_Q,ID_MCQ,Options")] table_3 Table_3)
        {
            /*Random id_f = new Random();
            Table_1.UID_F = id_f.Next();
            */
            Table_1.Form_Name = Request.Form["form-name"];
            Table_1.Creator = Request.Form["creators-name"];
            Table_1.Created_On = DateTime.Now.ToString("h:mm:ss ");
            _formRepository.Add_1(Table_1);


            int i = 0;
            while (true)
            {

                if (!string.IsNullOrEmpty(Request.Form[$"ques-{i}"]))
                {
                    Table_2 = new table_2();
                    Table_2.UID_F1 = Table_1.UID_F;
                    Table_2.Question_Type = Request.Form[$"sel-{i}"];
                    Table_2.Question = Request.Form[$"ques-{i}"];
                    _formRepository.Add_2(Table_2);


                    if (Table_2.Question_Type == "radio" || Table_2.Question_Type == "checkbox")
                    {

                        int j = 1;
                        while (true)
                        {

                            if (!string.IsNullOrEmpty(Request.Form[$"radio-{i}-{j}"]))
                            {
                                Table_3 = new table_3();
                                Table_3.F2 = Table_1.UID_F;
                                Table_3.UID_Q = Table_2.UID_Q;
                                Table_3.Options = Request.Form[$"radio-{i}-{j}"];
                                _formRepository.Add_3(Table_3);


                                j++;
                            }

                            else
                            {
                                break;
                            }

                        }


                    }
                      

                    i++;
                }

                else
                {
                    break;
                }



                
            }

            return RedirectToAction(nameof(Index));

        }


        /*[HttpPost]
        public IActionResult CreateForm( )
        {
            Random va = new Random();
            table_1 Table_1 = new table_1();
            Table_1.UID_F = va.Next();
            Table_1.Form_Name = Request.Form["form-name"];
            Table_1.Creator = Request.Form["creators-name"];
            Table_1.Created_On = DateTime.Now.ToString("h:mm:ss ");
            _formRepository.Add_1(Table_1);

            table_2 Table_2 = new table_2();
            int i = 0;
            while (true)
            {
                if (!string.IsNullOrEmpty(Request.Form[$"ques-{i}"]))
                {
                    Table_2.UID_F1 = Table_1.UID_F;
                    Table_2.UID_Q = i;
                    Table_2.Question_Type = Request.Form[$"sel-{i}"];
                    Table_2.Question = Request.Form[$"ques-{i}"];
                    _formRepository.Add_2(Table_2);



                    if (Table_2.Question_Type == "radio" || Table_2.Question_Type == "checkbox")
                    {
                        table_3 Table_3 = new table_3();
                        int j = 1;
                        
                        while (true)
                        {
                            if (!string.IsNullOrEmpty(Request.Form[$"radio-{i}-{j}"]))
                            {
                            
                                Table_3.F2 = Table_1.UID_F;
                                Table_3.UID_Q = i;
                                Table_3.ID_MCQ = j;
                                Table_3.Options = Request.Form[$"radio-{i}-{j}"];
                                _formRepository.Add_3(Table_3);
                                j++;
                            }
                            else
                                break;

                        }

                    }
                    i++;
                }
                else
                    break;

            }
            return RedirectToAction("Results", new { id = Table_1.UID_F });  // return View();
        }
       */
        public ActionResult Results(int id)
        {
           // tmp = 656501304;
            FormModelView formModelView = new FormModelView();
            formModelView.Table_1 = _formRepository.GetAll1(id);
            formModelView.list_2 = _formRepository.GetAll2(id);
            formModelView.list_3 = _formRepository.GetAll3(id);  
            return View(formModelView);
        }





        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _db.table_1s
                .Include(m => m.table_2)
                .ThenInclude(n => n.table_3)
                .FirstOrDefaultAsync(m => m.UID_F == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var form = await _db.table_1s.FindAsync(id);
            _db.table_1s.Remove(form);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }




    /* Formdumy formdumy = new Formdumy();
         formdumy.FormName = Request.Form["radio-0-1"];
         formdumy.FormName1 = Request.Form["radio-1-2"];
         formdumy.radio = Request.Form["radio-1-1"];
         return RedirectToAction("Results", "Home", formdumy);

         ViewBag.str = formdumy.FormName;
            ViewBag.str1 = formdumy.FormName1;
            ViewBag.str2 = formdumy.radio;


           return Content($"hello {formData.Agree}");
         */



}
