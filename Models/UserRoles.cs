using System.ComponentModel.DataAnnotations;

namespace MovieMania.Models
{
    public enum UserRoleType
    {
        [Display(Name = "Administration")]
        Admin = 0,
        [Display(Name = "Normal User")]
        User = 1
    }
}
