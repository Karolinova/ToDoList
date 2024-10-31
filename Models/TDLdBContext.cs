public class TDLdBContext: DbContext
{
    public TDLdBContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=server_name;Initial Catalog=ToDoList;Integrated Security=True;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}
