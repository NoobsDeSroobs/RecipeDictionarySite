using Microsoft.EntityFrameworkCore;

namespace RecipeDictionarySite
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Models.Recipe> Recipes { get; set; }


    }
}