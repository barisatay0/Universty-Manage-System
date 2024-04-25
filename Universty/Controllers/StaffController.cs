using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vize.Models;

namespace Vize.Controllers
{
    public class StaffController : Controller
    {
        UniversityDBEntities db = new UniversityDBEntities();

        public ActionResult Staff()
        {
            if (Session["UserId"] != null)
            {
                var staffvalue = db.Staff.ToList();
                return View(staffvalue);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public ActionResult NewStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewStaff(Staff p1)
        {
            db.Staff.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Staff");
        }

        public ActionResult Delete(int id)
        {
            var staff = db.Staff.Find(id);
            db.Staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Staff");
        }

        public ActionResult EditStaff(int id)
        {
            var staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View("EditStaff", staff);
        }

        [HttpPost]
        public ActionResult EditStaff(Staff p1)
        {
            var staff = db.Staff.Find(p1.id);
            if (staff != null)
            {
                staff.StaffName = p1.StaffName;
                staff.Starting = p1.Starting;
                staff.Ending = p1.Ending;
                db.SaveChanges();
                return RedirectToAction("Staff");
            }
            return HttpNotFound();
        }
    }
}