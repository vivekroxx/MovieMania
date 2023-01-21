using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = "123456",
                    Role = UserRole.Admin
                });
        }
    }
}
