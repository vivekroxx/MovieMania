using System.ComponentModel.DataAnnotations;

namespace MovieMania.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
