using Microsoft.EntityFrameworkCore;

public class ContextCrud: DbContext {
    public ContextCrud(DbContextOptions<ContextCrud> options) : base(options){

    }

    public DbSet<Client> Cliente {get; set;}
}