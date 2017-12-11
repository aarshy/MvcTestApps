using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Try1.Models;

namespace Try1.Controllers
{
    public class EnrollController : Controller
    {
        private ItTrainingEntitiesContext db = new ItTrainingEntitiesContext();

        //
        // GET: /Enroll/

        public ActionResult Index()
        {
            var enrolls = db.Enrolls.Include(e => e.Course).Include(e => e.Student);
            return View(enrolls.ToList());
        }

        //
        // GET: /Enroll/Details/5

        public ActionResult Details(int id = 0)
        {
            Enroll enroll = db.Enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        //
        // GET: /Enroll/Create

        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        //
        // POST: /Enroll/Create

        [HttpPost]
        public ActionResult Create(Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                db.Enrolls.Add(enroll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", enroll.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentName", enroll.StudentID);
            return View(enroll);
        }

        //
        // GET: /Enroll/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Enroll enroll = db.Enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", enroll.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentName", enroll.StudentID);
            return View(enroll);
        }

        //
        // POST: /Enroll/Edit/5

        [HttpPost]
        public ActionResult Edit(Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", enroll.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentName", enroll.StudentID);
            return View(enroll);
        }

        //
        // GET: /Enroll/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Enroll enroll = db.Enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        //
        // POST: /Enroll/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Enroll enroll = db.Enrolls.Find(id);
            db.Enrolls.Remove(enroll);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}