using ILEARN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ILEARN.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index(int? page)
        {
            using IlearnDbContext db = new();
            //var pageSize = 20;
            //var pageIndex = page ?? 1;
            var items = db.Courses.OrderBy(x => x.Id).ToList();
            return View(items);
        }

        public IActionResult GetCourse(int ID)
        {
            using IlearnDbContext db = new();
            var course = db.Courses.FirstOrDefault(m => m.Id == ID);
            if (course == null)
            {
                return RedirectToAction("NullPage", "Error");
            }
            else
            {
                return View(course);
            }
        }

        public IActionResult PriceIncreased(int? page)
        {
            using IlearnDbContext db = new();
            //var pageSize = 20;
            //var pageIndex = page ?? 1;
            var items = db.Courses.OrderBy(x => x.CoursePrice).ToList();
            return View(items);
        }

        public IActionResult PriceDecreased(int? page)
        {
            using IlearnDbContext db = new();
            //var pageSize = 20;
            //var pageIndex = page ?? 1;
            var items = db.Courses.OrderByDescending(x => x.CoursePrice).ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult Search(string search, int? page)
        {
            using IlearnDbContext db = new();
            //var pageSize = 20;
            //var pageIndex = page ?? 1;
            var items = db.Courses
                .AsEnumerable()
                .Where(c => RemoveDiacritics(c.CourseName.ToLower()).Contains(RemoveDiacritics(search.ToLower())))
                .OrderBy(c => c.Id)
                .ToList();
            TempData["count"] = items.Count;
            TempData["value"] = search;
            return View(items);
        }

        private static string RemoveDiacritics(string text)
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