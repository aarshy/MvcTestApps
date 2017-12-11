using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Try1.Models;

namespace Try1.Controllers
{
    public class MainController : Controller
    {
        private ItTrainingEntitiesContext db = new ItTrainingEntitiesContext();
        private CombinedModel combbinedNew = new CombinedModel();
        //
        // GET: /Main/

        public ActionResult Index()
        {
            CombinedModel cm = new CombinedModel();
            cm.ViewListCourse = db.Courses.ToList();
            cm.ViewListEnroll = db.Enrolls.ToList();
            cm.ViewListInstallment = db.Installments.ToList();
            cm.ViewListStudent = db.Students.ToList();
            return View(cm);
        }

        //
        // GET: /Main/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Main/Create

        public ActionResult Create()
        {


            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        //
        // POST: /Main/Create

        [HttpPost]
        public ActionResult Create(CombinedModel  cm, Enroll en)
        {
           
           
                try
                {
                   db.Students.Add(cm.ViewStudent);
                   db.SaveChanges();
                   cm.ViewEnroll.StudentID = cm.ViewStudent.StudentId;
                   cm.ViewEnroll.CourseID =(int)en.CourseID;
                   db.Enrolls.Add(cm.ViewEnroll);
                   db.SaveChanges();
                   cm.ViewInstallment.EnrollmentId = cm.ViewEnroll.EnrollId;
                   db.Installments.Add(cm.ViewInstallment);
                   db.SaveChanges();
                    // TODO: Add insert logic here

                   return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", cm.ViewEnroll.CourseID);
                    return View(cm);
                }

                return View("index");
            
            
        }

        //
        // GET: /Main/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Main/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Main/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Main/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
