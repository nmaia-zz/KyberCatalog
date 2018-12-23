using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}