using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OnlineEDUschoolManaementSystemMVC.Models.Data;
using System.Web.UI;
using System.Data.Common.CommandTrees;
using System.Data.Objects.SqlClient;
using System.Text;

namespace OnlineEDUschoolManaementSystemMVC.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index(int? page)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var pageSize = 20;
                var pageIndex = page ?? 1;
                var items = db.Courses.OrderBy(x => x.ID).ToPagedList(pageIndex, pageSize);
                return View(items);
            }
        } 

        public ActionResult GetCourse(int ID)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var course = db.Courses.FirstOrDefault(m=> m.ID == ID);
                return View(course);
            }
        }

        public ActionResult PriceIncreased(int? page) 
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var pageSize = 20;
                var pageIndex = page ?? 1;
                var items = db.Courses.OrderBy(x => x.coursePrice).ToPagedList(pageIndex, pageSize);
                return View(items);
            }
        }

        public ActionResult PriceDecreased(int? page)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var pageSize = 20;
                var pageIndex = page ?? 1;
                var items = db.Courses.OrderByDescending(x => x.coursePrice).ToPagedList(pageIndex, pageSize);
                return View(items);
            }
        }

        [HttpGet]
        public ActionResult Search(string search, int? page)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var pageSize = 20;
                var pageIndex = page ?? 1;
                var items = db.Courses
                    .AsEnumerable()
                    .Where(c => RemoveDiacritics(c.courseName.ToLower()).Contains(RemoveDiacritics(search.ToLower())))
                    .OrderBy(c=>c.ID)
                    .ToPagedList(pageIndex, pageSize);
                TempData["count"] = items.TotalItemCount;
                TempData["value"] = search;
                return View(items);
            }
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (char c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}