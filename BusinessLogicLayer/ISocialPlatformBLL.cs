using DataAccessLayer.Data.Entities;
using SocialPlatformsAPI.Data.Entities;
using SocialPlatformsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialPlatform = SocialPlatformsAPI.Data.Entities.SocialPlatform;

namespace BusinessLogicLayer
{
    public interface ISocialPlatformBLL
    {
        Task<List<SocialPlatformDto>> GetAllPlatforms();
        Task<SocialPlatform> GetSingle(int id);
        Task<SocialPlatformDto> GetWithTranslation(string languageKey,int id);
        Task <List<SocialPlatformFromAPI>> GetPlatformsWithPostsTypes();
        Task<List<SocialPlatform>> AddPlatform(SocialPlatform socialPlatform);
    }
}
