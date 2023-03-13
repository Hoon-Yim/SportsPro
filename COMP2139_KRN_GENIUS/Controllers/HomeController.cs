using Microsoft.AspNetCore.Mvc;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("about")]
        public ViewResult About()
        {
            return View();
        }
    }
}