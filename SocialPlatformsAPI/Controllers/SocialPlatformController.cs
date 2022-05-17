using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialPlatformsAPI.Data;
using SocialPlatformsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialPlatformsAPI.Data.Entities;
using BusinessLogicLayer;
using DataAccessLayer.Data.Entities;
using SocialPlatform = SocialPlatformsAPI.Data.Entities.SocialPlatform;

namespace SocialPlatformsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPlatformController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly ISocialPlatformBLL _iBLL;
        //public SocialPlatformController(DataContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}
        public SocialPlatformController(ISocialPlatformBLL iBLL)
        {
            _iBLL = iBLL;
        }


        //Get All
        [HttpGet]
        public async Task<ActionResult<List<SocialPlatformDto>>> GetAllPlatforms()
        {
            #region
            //get all platforms with translations
            //var socialPlatformsList = await _context.socialPlatforms.Include(x => x.Translations).ThenInclude(x => x.Language).ToListAsync();

            //map to dto
            //var result = new List<SocialPlatformDto>();
            //foreach (var item in socialPlatformsList)
            //{
            //    var tranlsationsDto = new List<SocialPlatformTranslationsDto>();
            //    foreach (var translation in item.Translations)
            //    {
            //        tranlsationsDto.Add(new SocialPlatformTranslationsDto()
            //        {
            //            LanguageKey = translation.Language.Key,
            //            Name = translation.Name
            //        });
            //    }

            //    result.Add(new SocialPlatformDto()
            //    {
            //        Id = item.Id,
            //        Key = item.Key,
            //        Translations = tranlsationsDto
            //    });
            //}

            //map dto using AutoMapper
            //var result = _mapper.Map<IEnumerable<SocialPlatformDto>>(socialPlatformsList);
            #endregion
            List<SocialPlatformDto> platforms = await _iBLL.GetAllPlatforms();
            return platforms;
        }

        ////Get Single
        [HttpGet("{id}")]
        public async Task<SocialPlatform> GetSingle(int id)
        {
            var platform = await _iBLL.GetSingle(id);
            return platform;
        }

        ////Get
        [HttpGet("getTranslated/{id}")]
        public async Task<SocialPlatformDto> GetWithTranslation([FromHeader] string languageKey, int id)
        { 
            var result = await _iBLL.GetWithTranslation(languageKey, id);
            return result;
        }
        [HttpGet("getwithposts")]
        public async Task<List<SocialPlatformFromAPI>> GetPlatformsWithPostsTypes()
        {
            var result = await _iBLL.GetPlatformsWithPostsTypes();
            return result;
        }

        ////Add
        [HttpPost]
        public async Task<List<SocialPlatform>> AddPlatform(SocialPlatform platform)
        {
            var result = await _iBLL.AddPlatform(platform);
            return result;
        }

        ////Update
        //[HttpPut("{id}")]
        //public async Task<ActionResult<List<SocialPlatform>>> UpdatePlatform(int id, SocialPlatform request)
        //{
        //    var platform = await _context.socialPlatforms.FindAsync(id);
        //    if (platform == null)
        //    {
        //        return NotFound("Platform not found");
        //    }
        //    if (!(String.IsNullOrEmpty(request.Key)))
        //        platform.Key = request.Key;
        //    if (!(String.IsNullOrEmpty(request.CreateDate)))
        //        platform.CreateDate = request.CreateDate;
        //    await _context.SaveChangesAsync();
        //    return Ok(await _context.socialPlatforms.ToListAsync());
        //}
        ////Delete
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<SocialPlatform>>> Delete(int id)
        //{
        //    var platform = await _context.socialPlatforms.FindAsync(id);
        //    if (platform == null)
        //    {
        //        return NotFound("Platform not found");
        //    }
        //    _context.socialPlatforms.Remove(platform);
        //    await _context.SaveChangesAsync();
        //    return Ok(await _context.socialPlatforms.ToListAsync());
        //}

    }
}
