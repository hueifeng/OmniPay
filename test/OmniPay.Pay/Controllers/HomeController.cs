using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Free.Pay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}