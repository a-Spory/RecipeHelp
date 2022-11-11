using Microsoft.EntityFrameworkCore;

namespace RecipeHelp.Models
{
    public class AppDbContext : DbContext
    {
        //FIELDS & PROPERTIES

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

        //CONSTRUCTORS

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        //METHODS
    }
}
