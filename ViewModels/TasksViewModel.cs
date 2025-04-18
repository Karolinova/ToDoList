using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList_gh.Models;

 public class TasksViewModel
 {
    public List<Zadania>? Zadanias { get; set; }
    public List<Zadania_zakonczone>? Zadania_Zakonczone { get; set; }
    public List<SelectListItem>? Slownik { get; set; }
    public Zadania Zadania { get; set; }
 }
