using System.ComponentModel.DataAnnotations;

namespace SocialPlatformsMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
