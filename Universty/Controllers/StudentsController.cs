using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vize.Models;
using Vize.ViewModels;
using System.Data.Entity;
using System.Net;

namespace Vize.Controllers
{
    public class StudentsController : Controller
    {
        UniversityDBEntities db = new UniversityDBEntities();

        public ActionResult Students()
        {
            if (Session["UserId"] != null)
            {
                var studentvalue = db.Students.ToList();
                return View(studentvalue);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public ActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewStudent(Students p1)
        {
            db.Students.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Students");
        }

        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Students");
        }

        public ActionResult EditStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View("EditStudent",student);
        }

        [HttpPost]
        public ActionResult EditStudent(Students p1)
        {
            var student = db.Students.Find(p1.id);
            if (student != null)
            {
                student.StudentName = p1.StudentName;
                student.Faculty = p1.Faculty;
                student.SchoolNo = p1.SchoolNo;
                student.Credit = p1.Credit;
                db.SaveChanges();
                return RedirectToAction("Students");
            }
            return HttpNotFound();
        }
    }

}

