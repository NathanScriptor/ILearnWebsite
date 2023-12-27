using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEDUschoolManaementSystemMVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NoPrivilege()
        {
            return View();
        }
    }
}