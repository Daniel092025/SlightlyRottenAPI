
//Database ORM for MovieDatabaseSQL.db

namespace Project.Database
{
    public class MovieDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MovieDatabaseSQL.db");
        }
    }

    
}
