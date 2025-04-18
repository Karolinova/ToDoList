using System.ComponentModel.DataAnnotations;

namespace ToDoList_gh.Models
{
    public class Uzytkownik
    {
        [Key]
        public int IdUzytkownik { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        public string Haslo { get; set; }
    }
}
