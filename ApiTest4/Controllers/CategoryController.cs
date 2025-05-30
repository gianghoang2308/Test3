using Microsoft.AspNetCore.Mvc;

namespace ApiTest4.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
