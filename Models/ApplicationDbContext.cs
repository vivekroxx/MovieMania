using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<MoviesModel> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
