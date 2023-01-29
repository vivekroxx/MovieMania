using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
