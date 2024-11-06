[Table("Zadania")]
public class Zadania
{
    [Key]
    public int Zadanie_id { get; set; }
    public string Zadanie { get; set; } = string.Empty;
    public string Opis { get; set; } = string.Empty;
    public DateTime? DoTime { get; set; }
    public DateTime StartTime { get; set; } = DateTime.Now;
}
