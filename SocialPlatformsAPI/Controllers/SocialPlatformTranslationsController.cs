//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SocialPlatformsAPI.Data;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace SocialPlatformsAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SocialPlatformTranslationsController : ControllerBase
//    {
//        private readonly DataContext _context;
//        public SocialPlatformTranslationsController(DataContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        public async Task<ActionResult<List<SocialPlatformTranslations>>> GetTranslations()
//        {
//            return Ok(await _context.SocialPlatformTranslations.ToListAsync());
//        }
//        [HttpPost]
//        public async Task<ActionResult<List<SocialPlatformTranslations>>> AddTranslation(SocialPlatformTranslations newTranslation)
//        {
//            _context.SocialPlatformTranslations.Add(newTranslation);
//            await _context.SaveChangesAsync();
//            return Ok(await _context.SocialPlatformTranslations.ToListAsync());
//        }


//        //[HttpPut("{id}")]
//        //public async Task<ActionResult<List<SocialPlatformTranslations>>> UpdateTranslation(int id, SocialPlatformTranslations newTranslation)
//        //{
//        //    var translation = await _context.socialPlatformTranslations.FindAsync(id);
//        //    if (translation == null)
//        //    {
//        //        return NotFound("Translation not found");
//        //    }
//        //    if (newTranslation.LanguageId != null)
//        //    {
//        //        translation.LanguageId = newTranslation.LanguageId;
//        //    }
//        //    if (newTranslation.SocialPlatformId != null)
//        //    {
//        //        translation.SocialPlatformId = newTranslation.SocialPlatformId;
//        //    }
//        //    if (!(String.IsNullOrEmpty(newTranslation.Name)))
//        //    {
//        //        translation.Name = newTranslation.Name;
//        //    }
//        //    await _context.SaveChangesAsync();
//        //    return Ok(_context.socialPlatformTranslations.ToListAsync());
//        //}

//        //[HttpDelete("{id}")]
//        //[ValidateAntiForgeryToken]
//        //public async Task<ActionResult> DeleteTranslation(int id)
//        //{
//        //    var translation = await _context.socialPlatformTranslations.FindAsync(id);
//        //    if (translation == null)
//        //    {
//        //        return NotFound("Translation is not found");
//        //    }
//        //    _context.socialPlatformTranslations.Remove(translation);
//        //    await _context.SaveChangesAsync();
//        //    return Ok(await _context.socialPlatformTranslations.ToListAsync());
//        //}

//    }
//}
