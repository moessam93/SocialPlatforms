using DataAccessLayer.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformsAPI.Data.Entities;
using SocialPlatformsMVC.Models;
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
            SocialPlatformPostTypesViewModel _postType = new SocialPlatformPostTypesViewModel();
            _postType.SocialPlatforms = socialPlatforms;
            return PartialView("_SocialPlatformPostTypesPartial",_postType);
        }
        [HttpPost]
        public IActionResult AddPostType(SocialPlatformPostTypesViewModel postType)
        {
            //var _socialPlatform = _context.socialPlatforms.Where(x=>x.Key == postType.SocialPlatform.Key).First();
            //postType.SocialPlatform = _socialPlatform;
            SocialPlatformPostTypes _postType = new SocialPlatformPostTypes();
            _postType.SocialPlatformId = postType.SocialPlatformId;
            _postType.Key = postType.Key;
            _context.SocialPlatformPostTypes.Add(_postType);
            _context.SaveChanges();
            return PartialView("_SocialPlatformPostTypesPartial", postType);
        }
    }
}
