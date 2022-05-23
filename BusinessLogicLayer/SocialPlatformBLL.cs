using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Dto;
using DataAccessLayer;
using DataAccessLayer.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceStack.Configuration;
using SocialPlatformsAPI.Data.Entities;
using SocialPlatformsAPI.Dto;
using SocialPlatform = SocialPlatformsAPI.Data.Entities.SocialPlatform;

namespace BusinessLogicLayer
{
    public class SocialPlatformBLL:ISocialPlatformBLL
    {
        //private DataAccessLayer.SocialPlatformDAL _DAL;
        private readonly ISocialPlatformDAL _iDAL;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SocialPlatformBLL(IMapper mapper, ISocialPlatformDAL iDAL, IHttpClientFactory clientFactory, IConfiguration configuration, DataContext context, IHttpContextAccessor httpContextAccessor )
        {
            _mapper = mapper;
            _iDAL = iDAL;
            _clientFactory = clientFactory;
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<SocialPlatformsDTO_2>> GetAllPlatforms()
        {

            //get all platforms with translations
            var languageId = 1;
            var socialPlatforms = await _iDAL.GetAllPlatforms();
            var _socialPlatforms = new List<SocialPlatformsDTO_2>();
            var translations = _context.SocialPlatformTranslations.ToList();
            var languages = _context.languages.ToList();
            var languageKey = _httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "languagekey");
            
                languageId = languages.FirstOrDefault(x=>x.Key==languageKey.Value[0]).Id;
            
            
            foreach (var platform in socialPlatforms)
            {
                var _socialPlatform = new SocialPlatformsDTO_2();
                _socialPlatform.Id = platform.Id;
                if (translations.FirstOrDefault(x => x.LanguageId == languageId && x.SocialPlatformId == _socialPlatform.Id) != null)
                {
                    _socialPlatform.Name = translations.FirstOrDefault(x => x.LanguageId == languageId && x.SocialPlatformId == _socialPlatform.Id).Name;
                }
                _socialPlatforms.Add(_socialPlatform);
            }
            //map dto using AutoMapper
            return _socialPlatforms;
        }

        //Get Single
        public async Task<SocialPlatform> GetSingle(int id)
        {
            var socialPlatform = await _iDAL.GetSingle(id);
            
            return socialPlatform;
        }

        public async Task<SocialPlatformDto> GetWithTranslation([FromHeader] string languageKey,int id)
        {
            var socialPlatform = await _iDAL.GetWithTranslation(languageKey, id);
            var result = _mapper.Map<SocialPlatformDto>(socialPlatform);
            result.Translation = socialPlatform.Translations.FirstOrDefault(c => c.Language.Key == languageKey).Name;
            return result;
        }
        public async Task<List<SocialPlatformFromAPI>> GetPlatformsWithPostsTypes()
        {
            IAppSettings appSettings = new AppSettings();
            var urlPlatforms = _configuration.GetSection("URI").GetSection("Lookups").Value+ "/api/lookups/SocialPlatform";
            var urlPostsTypes = _configuration.GetSection("URI").GetSection("Lookups").Value+"/api/lookups/SocialPlatformPostType";
            var client = _clientFactory.CreateClient();
            var responsePlatforms = await client.GetAsync(urlPlatforms);
            var responsePostsTypes = await client.GetAsync(urlPostsTypes);

            var responsePlatformsBody = await responsePlatforms.Content.ReadAsStringAsync();
            var responsePostsTypesBody = await responsePostsTypes.Content.ReadAsStringAsync();

            var serializedPlatforms = JsonSerializer.Deserialize<SocialPlatformsFromAPI>(responsePlatformsBody);
            var socialPlatforms = serializedPlatforms.SocialPlatforms.ToList();

            var serializedPostsTypes = JsonSerializer.Deserialize<PostsTypesFromAPI>(responsePostsTypesBody);
            var postsTypes = serializedPostsTypes.PostsTypes.ToList();

            foreach (var platform in socialPlatforms)
            {
                //var socialPlatformPostTypes = postsTypes.Where(p => p.SocialPlatformId == platform.Id).ToList();
                //platform.PostsTypes = socialPlatformPostTypes;


                platform.PostsTypes = new List<PostsTypes>();
                foreach (var postType in postsTypes)
                {
                    if (platform.Id == postType.SocialPlatformId)
                        platform.PostsTypes.Add(postType);
                }
            }

            return socialPlatforms;
        }
        public async Task<List<SocialPlatform>> AddPlatform(SocialPlatform platform)
        {
            List<SocialPlatform> socialPlatforms = await _iDAL.AddPlatform(platform);
            return socialPlatforms; 
        }


    }
}
