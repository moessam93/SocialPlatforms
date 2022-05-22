using DataAccessLayer.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformsAPI.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SocialPlatformsMVC.Controllers
{
    public class SocialPlatformPostTypesController : Controller
    {
        private readonly DataContext _context;
        public SocialPlatformPostTypesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var socialPlatformPostTypes = _context.SocialPlatformPostTypes.ToList();
            return View(socialPlatformPostTypes);
        }
        [HttpGet]
        public IActionResult AddPostType()
        {
            SocialPlatformPostTypes postType = new SocialPlatformPostTypes();
            List<SocialPlatform> socialPlatforms = _context.socialPlatforms.ToList();
            ViewBag.AllSocialPlatforms = socialPlatforms;
            return PartialView("_SocialPlatformPostTypesPartial",postType);
        }
        [HttpPost]
        public IActionResult AddPostType(SocialPlatformPostTypes postType)
        {
            //var _socialPlatform = _context.socialPlatforms.Where(x=>x.Key == postType.SocialPlatform.Key).First();
            //postType.SocialPlatform = _socialPlatform;
            _context.SocialPlatformPostTypes.Add(postType);
            _context.SaveChanges();
            return PartialView("_SocialPlatformPostTypesPartial", postType);
        }
    }
}
