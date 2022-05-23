using BusinessLogicLayer;
using BusinessLogicLayer.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize]
        public async Task<ActionResult<List<SocialPlatformsDTO_2>>> Index()
        {
            List<SocialPlatformsDTO_2> platforms = await _iBLL.GetAllPlatforms();
            return View(platforms);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddPlatform()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<List<SocialPlatform>>> AddPlatform(SocialPlatform platform)
        {
            await _iBLL.AddPlatform(platform);
            return RedirectToAction("Index");
        }
    }
}
