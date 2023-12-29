using ILEARN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ILEARN.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Signin()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser != null && claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserHome", "Home");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(VMLogin modelLogin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (modelLogin.Email == "admin" && modelLogin.Password == "123456")
            {
                return RedirectToAction("Index", "HomeAdmin");
            }

            IlearnDbContext db = new();
            var account = db.Accounts.FirstOrDefault(m => m.Username == modelLogin.Email && m.Password == modelLogin.Password);
            
            if (account != null)
            {
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim(ClaimTypes.Name, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")
                };

                ClaimsIdentity claimsIdentity = new(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                foreach (var claim in claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }

                AuthenticationProperties properties = new()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng !";
                return RedirectToAction("Signin");
            }
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string name, string username, string phone, string password1, string password2)
        {
            IlearnDbContext db = new();
            if (password1 != password2)
            {
                Account account = new() { Username = username, Password = password1, Role = 1, UserStatus = 1};
                db.Accounts.Add(account);
                db.SaveChanges();
                Account acc = db.Accounts.First(a => a.Username == username);
                Student student = new() { Email = username, Name = name, Phone = phone, AccountId = acc.Id };
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