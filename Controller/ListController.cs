// ListController for methods for application
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
}
