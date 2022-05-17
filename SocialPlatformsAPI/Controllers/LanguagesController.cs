using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialPlatformsAPI.Data;
using SocialPlatformsAPI.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        //private readonly DataContext _context;
        //public LanguagesController(DataContext context)
        //{
        //    _context = context;
        //}

        private BusinessLogicLayer.LanguagesBLL _BLL;
        public LanguagesController()
        {
            _BLL = new BusinessLogicLayer.LanguagesBLL();
        }

        [HttpGet]
        public async Task<ActionResult<List<Languages>>> GetAllLanguages()
        {
            return await _BLL.GetAllLanguages();
        }
        [HttpPost]
        public async Task<ActionResult<List<Languages>>> AddLanguage(Languages language)
        {
            return await _BLL.AddLanguage(language);
        }
    }
}
