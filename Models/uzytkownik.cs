public class Uzytkownik
{
    [Key]
    public int IdUzytkownik { get; set; }
    public string Login { get; set; }
    public string Haslo { get; set; }
}
