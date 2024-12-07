public class TDLdBContext: DbContext
{
    public TDLdBContext()
    {

    }

    public DbSet<Zadania> Zadanias { get; set; }
    public DbSet<Zadania_zakonczone> Zadania_zakonczone { get; set; }
    public DbSet<Slownik> Slownik { get; set; }
    public DbSet<Uzytkownik> Uzytkownik { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=server_name;Initial Catalog=ToDoList;Integrated Security=True;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}
