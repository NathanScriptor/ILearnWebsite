using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using OnlineEDUschoolManaementSystemMVC.Models.Data;

namespace OnlineEDUschoolManaementSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var items = db.Courses.OrderBy(x => x.ID).ToList();
                return View(items);
            }
        }
    }
}