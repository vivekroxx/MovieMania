using Microsoft.AspNetCore.Identity;

namespace MovieMania.Data
{
    public class ApplicationRole : IdentityRole<int>
    {
        public int ClinicId { get; set; }
        public string FriendlyName { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationUser : IdentityUser<int>
    {
        public DateTimeOffset? LastLoginDate { get; set; }
        public virtual ICollection<ApplicationUserLogin> UserLogins { get; } = new List<ApplicationUserLogin>();
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
        public virtual ICollection<ApplicationUserToken> UserTokens { get; } = new List<ApplicationUserToken>();
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserRefreshToken
    {
        public int Id { get; set; }

        public virtual int UserId { get; set; }

        public string Token { get; set; }

        public DateTimeOffset Expires { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
