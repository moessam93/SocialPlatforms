using Microsoft.AspNetCore.Mvc;

namespace SocialPlatformsMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
