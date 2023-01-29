using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<MovieModel> Movies { get; set; }
        public virtual DbSet<FavoriteMovieModel> FavoriteMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();

            //builder.Entity<CustomUser>(b =>
            //{
            //    b.HasKey(u => u.Id);
            //    b.HasOne(u => u.User)
            //        .WithOne(u => u.CustomUser)
            //        .HasForeignKey<CustomUser>(p => p.Id)
            //        .IsRequired();
            //    b.Property(p => p.Id)
            //        .ValueGeneratedNever();
            //});
        }
    }
}
