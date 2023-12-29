using Microsoft.AspNetCore.Mvc;

namespace ILEARN.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
