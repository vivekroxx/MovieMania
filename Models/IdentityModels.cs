using Microsoft.AspNetCore.Identity;

namespace MovieMania.Models
{
    public class ApplicationRole : IdentityRole<int>
    {

    }

    public class ApplicationUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public UserRoleType Role { get; set; }
    }
}
