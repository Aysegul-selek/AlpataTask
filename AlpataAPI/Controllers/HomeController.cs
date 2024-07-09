using Microsoft.AspNetCore.Mvc;

namespace AlpataAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
