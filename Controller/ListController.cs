// ListController for methods for application
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList_gh.Models;
using ToDoList_gh.ViewModels;

namespace ToDoList_gh.Controllers
{
    public class ListController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Uzytkownik user)
        {

            var dbContext = new TDLdBContext();
            var uzytkLog = dbContext.Uzytkownik.Where(a => a.Login == user.Login).Count();
            var uzytkHas = dbContext.Uzytkownik.Where(a => a.Haslo == user.Haslo).Count();
            if (uzytkLog > 0 && uzytkHas > 0)
            {
                return View("ListOfTasks");//redirect to main page with list of tasks
            }
            else
            {
                return View(user);
            }
            //return View(user);
        }

        public IActionResult ListOfTasks()
        {
            var dbContext = new TDLdBContext();
            var zad = dbContext.Zadanias.Include(x => x.Slownik).ToList();
            var zadEnd = dbContext.Zadania_zakonczone.Include(z => z.Zadania).ToList();
            var tvm = new TasksViewModel
            {
                Zadanias = zad,
                Zadania_Zakonczone = zadEnd
            };
            return View(tvm);
        }
        public IActionResult AddTask()
        {
            var dbContext = new TDLdBContext();
            var slowniki = dbContext.Slownik.Select(x => new SelectListItem(x.nazwa, x.slownik_id + "")).ToList();
            return View(new TasksViewModel
            {
                Zadania = new Zadania(),
                Slownik = slowniki
            });
        }
        [HttpPost]
        public IActionResult AddTask(TasksViewModel vm)
        {
            using (var dbContext = new TDLdBContext())
            {
                if (ModelState.IsValid == true)
                {
                    var noweZadanie = new Zadania
                    {
                        //  Zadanie_id = vm.Zadanias[0].Zadanie_id,
                        Zadanie = vm.Zadania.Zadanie,
                        Opis = vm.Zadania.Opis,
                        DoTime = vm.Zadania.DoTime,
                        StartTime = DateTime.Now,
                        slownik_id = vm.Zadania.slownik_id //Zadania.slownik_id
                    };
                    dbContext.Zadanias.Add(noweZadanie);
                    dbContext.SaveChanges();
                    var noweZadEnd = new Zadania_zakonczone
                    {
                        Zadanie_id = noweZadanie.Zadanie_id,
                    };
                    dbContext.Zadania_zakonczone.Add(noweZadEnd);
                    dbContext.SaveChanges();
                    return RedirectToAction("ListOfTasks");
                }
                var slowniki = dbContext.Slownik.Select(x => new SelectListItem(x.nazwa, x.slownik_id + "")).ToList();
                vm.Slownik = slowniki;
                return View(vm);
            }
        }

                public IActionResult DeleteTask(int id)
        {
            var dbContext = new TDLdBContext();
            var TaskToDelete = new Zadania();
            var TaskEndToDelete = new Zadania_zakonczone();
            TaskToDelete.Zadanie_id = id;
            TaskEndToDelete.Zadanie_id = TaskToDelete.Zadanie_id;
            dbContext.Zadanias.Attach(TaskToDelete);
            dbContext.Zadanias.Remove(TaskToDelete);
            dbContext.Zadania_zakonczone.Remove(TaskEndToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("ListOfTasks");
        }
    }
}