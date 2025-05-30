using Microsoft.AspNetCore.Mvc;

namespace ApiTest4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
