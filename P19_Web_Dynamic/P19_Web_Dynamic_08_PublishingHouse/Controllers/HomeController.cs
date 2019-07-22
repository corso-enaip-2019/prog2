using Microsoft.AspNetCore.Mvc;

namespace P19_Web_Dynamic_08_PublishingHouse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
