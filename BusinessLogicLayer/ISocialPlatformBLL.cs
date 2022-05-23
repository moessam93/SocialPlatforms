using BusinessLogicLayer.Dto;
using DataAccessLayer.Data.Entities;
using Microsoft.AspNetCore.Http;
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
        Task<List<SocialPlatformsDTO_2>> GetAllPlatforms();
        Task<SocialPlatform> GetSingle(int id);
        Task<SocialPlatformDto> GetWithTranslation(string languageKey,int id);
        Task <List<SocialPlatformFromAPI>> GetPlatformsWithPostsTypes();
        Task<List<SocialPlatform>> AddPlatform(SocialPlatform socialPlatform);
    }
}
