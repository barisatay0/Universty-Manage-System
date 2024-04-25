using System.Linq;
using System.Web.Mvc;
using Vize.Models;
using Vize.ViewModels;

namespace Vize.Controllers
{
    public class LoginController : Controller
    {
        private readonly UniversityDBEntities _context;

        public LoginController()
        {
            _context = new UniversityDBEntities();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Administrative.FirstOrDefault(u => u.SchoolMail == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Session["UserId"] = user.id;
                    Session["AdminName"] = user.Admin;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email Or Password.");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Login");
        }
    }
}
