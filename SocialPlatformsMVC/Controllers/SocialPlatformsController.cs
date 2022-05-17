using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformsAPI.Data.Entities;
using SocialPlatformsAPI.Dto;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformsMVC.Controllers
{
    public class SocialPlatformsController : Controller
    {
        private readonly ISocialPlatformBLL _iBLL;
        public SocialPlatformsController(ISocialPlatformBLL iBLL)
        {
            _iBLL = iBLL;
        }
        [HttpGet]
        public async Task<ActionResult<List<SocialPlatformDto>>> Index()
        {
            List<SocialPlatformDto> platforms = await _iBLL.GetAllPlatforms();
            return View(platforms);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<SocialPlatformDto>> GetSingle(int id)
        //{
        //    var platform = await _iBLL.GetSingle(id);
        //    return View(platform);
        //}
        
        [HttpGet]
        public IActionResult AddPlatform()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<List<SocialPlatform>>> AddPlatform(SocialPlatform platform)
        {
            await _iBLL.AddPlatform(platform);
            return RedirectToAction("GetAllPlatforms");
        }
    }
}
