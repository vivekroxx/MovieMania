using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                 new IdentityRole { Name = "User", NormalizedName = "USER" }
             );
        }
    }
}
