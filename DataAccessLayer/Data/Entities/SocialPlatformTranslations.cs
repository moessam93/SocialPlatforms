using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialPlatformsAPI.Data.Entities
{
    public class SocialPlatformTranslations
    {
        [Key, Column(Order = 0)]
        public int SocialPlatformId { get; set; }
        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public SocialPlatform SocialPlatform { get; set; }
        public Languages Language { get; set; }
    }

    //student
    //courses
    //studentCourses studentId, courseId
}
