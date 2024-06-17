namespace ApiPeaje.Data
{
    public class ApplicationdDbContext : DbContext 
    {
        public ApplicationdDbContext ()
        {
        }

        public ApplicationdDbContext(DbContextOptions<ApplicationdDbContext> options) : base(options) { }   
        public DbSet<Peaje> peajes { get; set; }
    }
}
