using System.Collections.Generic;

namespace SocialPlatformsAPI.Dto
{
    public class SocialPlatformDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Translation { get; set; }
        public ICollection<SocialPlatformTranslationsDto> Translations { get; set; }
    }
}
