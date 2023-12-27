using OnlineEDUschoolManaementSystemMVC.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineEDUschoolManaementSystemMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Signin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SignInWithUserAndPassword")]
        public ActionResult SignIn(string user, string password)
        {
            WebsiteDBEntities db = new WebsiteDBEntities();
            var account = db.Accounts.SingleOrDefault(m => m.username.ToLower() == user.ToLower() && m.password == password);
            if (account != null)
            {
                //Tạo session và gán giá trị
                Session["user"] = account;
                return RedirectToAction("Index","HomeAdmin");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng !";
                return RedirectToAction("Signin");
            }
        }

        public ActionResult SignOut()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(string name, string username, string phone, string password1, string password2)
        {
            WebsiteDBEntities db = new WebsiteDBEntities();
            if (password1 != password2)
            {
                Account account = new Account { username = username, password = password1, role = 1, userStatus = 1};
                db.Accounts.Add(account);
                db.SaveChanges();
                Account acc = db.Accounts.FirstOrDefault(a => a.username == username);
                Student student = new Student { email = username, name = name, phone = phone, accountID = acc.ID };
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Signin", "Authentication");
            }
            else
            {
                TempData["error"] = "Mật khẩu không giống nhau.";
                return RedirectToAction("Signup");
            }
        }
    }
}