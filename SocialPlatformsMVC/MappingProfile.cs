using AutoMapper;
using SocialPlatformsAPI.Data.Entities;
using SocialPlatformsAPI.Dto;

namespace SocialPlatformsAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SocialPlatform, SocialPlatformDto>();
            CreateMap<SocialPlatformTranslations, SocialPlatformTranslationsDto>();
        }
    }
}
