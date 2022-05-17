using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Entities
{
    public class SocialPlatformsFromAPI
    {

        [JsonPropertyName("response")]
        public SocialPlatformFromAPI[] SocialPlatforms { get; set; }
    }
    public class SocialPlatformFromAPI
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        public List<PostsTypes> PostsTypes { get; set; }
    }
}
