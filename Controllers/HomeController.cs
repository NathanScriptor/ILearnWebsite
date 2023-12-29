using ILEARN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ILEARN.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using IlearnDbContext db = new();
            var items = db.Courses.OrderBy(x => x.Id).ToList();
            return View(items);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
