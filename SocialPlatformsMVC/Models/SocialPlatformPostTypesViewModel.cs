using SocialPlatformsAPI.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialPlatformsMVC.Models
{
    public class SocialPlatformPostTypesViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Social Platform")]
        public int SocialPlatformId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Key { get; set; }
        public List<SocialPlatform> SocialPlatforms { get; set; }
    }
}
