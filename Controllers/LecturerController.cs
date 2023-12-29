using ILEARN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ILEARN.Controllers
{
    public class LecturerController : Controller
    {
        public IActionResult Index(int ID)
        {
            using IlearnDbContext db = new();
            var lecturer = db.Lecturers.FirstOrDefault(m => m.Id == ID);
            return View(lecturer);
        }
        public bool FunctionCheck(int functionID)
        {
            IlearnDbContext db = new();
            Account gv = (Account)ViewData["user"];
            if (gv != null)
            {
                int count = db.Decentralizations.Count(m => m.AccountId == gv.Id && m.FunctionId == functionID);
                if (count == 0)
                {
                    //báo không có quyền
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else return true;
        }
        public IActionResult LecturerList()
        {
            if (FunctionCheck(1) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }

            using IlearnDbContext db = new();
            var items = db.Lecturers.OrderBy(x => x.Id).ToList();
            return View(items);
        }

        public IActionResult AddLecturer()
        {
            if (FunctionCheck(2) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }
            return View();
        }

        public IActionResult UpdateLecturer() 
        {
            if (FunctionCheck(3) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }
            return View();
        }

        public IActionResult DeleteLecturer()
        {
            if (FunctionCheck(4) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }
            return View();
        }

        [HttpPost]
        [ActionName("AddNewLecturer")]
        public IActionResult AddLecturer(string name, string email, string description, string phone, string img) 
        {
            IlearnDbContext db = new();
            Lecturer lecturer = new() { LecturerName = name, Email = email, Description = description, Phone = phone, Img = img};
            db.Lecturers.Add(lecturer);
            db.SaveChanges();
            return RedirectToAction("LecturerList");
        }
    }
}