using ILEARN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ILEARN.Controllers
{
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}