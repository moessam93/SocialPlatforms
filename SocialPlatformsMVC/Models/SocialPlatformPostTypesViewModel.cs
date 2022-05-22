using System.ComponentModel.DataAnnotations;

namespace SocialPlatformsMVC.Models
{
    public class SocialPlatformPostTypesViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Social Platform")]
        public string SocialPlatform { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Key { get; set; }
    }
}
