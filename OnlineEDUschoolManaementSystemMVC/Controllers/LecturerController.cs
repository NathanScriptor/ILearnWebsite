using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEDUschoolManaementSystemMVC.Models.Data;

namespace OnlineEDUschoolManaementSystemMVC.Controllers
{
    public class LecturerController : Controller
    {
        public ActionResult Index(int ID)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var lecturer = db.Lecturers.FirstOrDefault(m => m.ID == ID);
                return View(lecturer);
            }
        }
        public bool FunctionCheck(int functionID)
        {
            WebsiteDBEntities db = new WebsiteDBEntities();
            Account gv = (Account)Session["user"];
            if (gv != null)
            {
                int count = db.Decentralizations.Count(m => m.accountID == gv.ID && m.functionID == functionID);
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
        public ActionResult LecturerList()
        {
            if (FunctionCheck(1) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var items = db.Lecturers.OrderBy(x => x.ID).ToList();
                return View(items);
            }
        }

        public ActionResult AddLecturer()
        {
            if (FunctionCheck(2) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }
            return View();
        }

        public ActionResult UpdateLecturer() 
        {
            if (FunctionCheck(3) == false)
            {
                //báo không có quyền
                return Redirect("/Controllers/Error");
            }
            return View();
        }

        public ActionResult DeleteLecturer()
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
        public ActionResult AddLecturer(string name, string email, string description, string phone, string img) 
        {
            WebsiteDBEntities db = new WebsiteDBEntities();
            Lecturer lecturer = new Lecturer { lecturerName = name, email = email, description = description, phone = phone, img = img};
            db.Lecturers.Add(lecturer);
            db.SaveChanges();
            return RedirectToAction("LecturerList");
        }
    }
}