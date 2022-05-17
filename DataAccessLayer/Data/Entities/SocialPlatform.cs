using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SocialPlatformsAPI.Data.Entities
{
    public class SocialPlatform
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string CreateDate { get; set; }
        public ICollection<SocialPlatformTranslations> Translations { get; set; }
    }

    //facebook
    //dev 1

    //testing
    //2


}
