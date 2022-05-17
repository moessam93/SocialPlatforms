using SocialPlatformsAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ISocialPlatformDAL
    {
        Task<List<SocialPlatform>> GetAllPlatforms();
        Task<SocialPlatform> GetSingle(int id);
        Task<SocialPlatform> GetWithTranslation(string languageKey, int id);
        Task<List<SocialPlatform>> AddPlatform(SocialPlatform platform);
    }
}
