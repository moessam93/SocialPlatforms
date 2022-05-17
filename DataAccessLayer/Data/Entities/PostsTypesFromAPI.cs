using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Entities
{
    public class PostsTypesFromAPI
    {
        [JsonPropertyName("response")]
        public PostsTypes [] PostsTypes { get; set; }
    }
    public class PostsTypes
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("socialPlatformId")]
        public int SocialPlatformId { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }

    }
}
