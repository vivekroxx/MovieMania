using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                 new ApplicationRole { Id = 1, Name = UserRoleType.Admin.ToString(), NormalizedName = UserRoleType.Admin.ToString().ToUpper() },
                 new ApplicationRole { Id = 2, Name = UserRoleType.User.ToString(), NormalizedName = UserRoleType.User.ToString().ToUpper() }
             );
        }
    }
}
