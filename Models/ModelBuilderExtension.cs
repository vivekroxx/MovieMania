using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public static class ModelBuilderExtension
    {
        public async static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole { Name = UserRoleType.Admin.ToString(), NormalizedName = UserRoleType.Admin.ToString().ToUpper() },
                 new IdentityRole { Name = UserRoleType.User.ToString(), NormalizedName = UserRoleType.User.ToString().ToUpper() }
             );

            //var roleAdmin = UserRoleType.Admin.ToString();
            //var roleUser = UserRoleType.User.ToString();

            //if (!await roleManager.RoleExistsAsync(roleAdmin))
            //{
            //    var adminRole = new IdentityRole(roleAdmin);
            //    await roleManager.CreateAsync(adminRole);

            //}
            //if (!await roleManager.RoleExistsAsync(roleUser))
            //{
            //    var standardRole = new IdentityRole(roleUser);
            //    await roleManager.CreateAsync(standardRole);
            //}
        }
    }
}
