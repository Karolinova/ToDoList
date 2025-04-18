using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList_gh.Models
{
    [Table("Zadania")]
    public class Zadania
    {
        [Key]
        public int Zadanie_id { get; set; }
        [Required(ErrorMessage = "Nazwa zadania jest wymagana")]
        public string Zadanie { get; set; } = string.Empty;
        [Required(ErrorMessage = "Opis zadania jest wymagany")]
        public string Opis { get; set; } = string.Empty;
        public DateTime? DoTime { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Wybierz priorytet")]
        
        public int slownik_id { get; set; }
        [ForeignKey("slownik_id")]
        public Slownik? Slownik { get; set; }
        
        public Zadania_zakonczone? ZadanieZakonczone { get; set; }
    }
}