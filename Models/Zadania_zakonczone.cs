 [Table("Zadania_zakonczone")]
 public class Zadania_zakonczone
 {
     [Key]
     public int Zadanie_id { get; set; }
     public DateTime? FinishTime { get; set; }
     [ForeignKey("Zadanie_id")]
     public Zadania Zadania { get; set; }
 }
