using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Try1.Models
{
    public class InstallmentController : Controller
    {
        private ItTrainingEntitiesContext db = new ItTrainingEntitiesContext();

        //
        // GET: /Installment/

        public ActionResult Index()
        {
            var installments = db.Installments.Include(i => i.Enroll);
            return View(installments.ToList());
        }

        //
        // GET: /Installment/Details/5

        public ActionResult Details(int id = 0)
        {
            Installment installment = db.Installments.Find(id);
            if (installment == null)
            {
                return HttpNotFound();
            }
            return View(installment);
        }

        //
        // GET: /Installment/Create

        public ActionResult Create()
        {
            ViewBag.EnrollmentId = new SelectList(db.Enrolls, "EnrollId", "EnrollId");
            return View();
        }

        //
        // POST: /Installment/Create

        [HttpPost]
        public ActionResult Create(Installment installment)
        {
            if (ModelState.IsValid)
            {
                db.Installments.Add(installment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnrollmentId = new SelectList(db.Enrolls, "EnrollId", "EnrollId", installment.EnrollmentId);
            return View(installment);
        }

        //
        // GET: /Installment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Installment installment = db.Installments.Find(id);
            if (installment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnrollmentId = new SelectList(db.Enrolls, "EnrollId", "EnrollId", installment.EnrollmentId);
            return View(installment);
        }

        //
        // POST: /Installment/Edit/5

        [HttpPost]
        public ActionResult Edit(Installment installment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(installment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnrollmentId = new SelectList(db.Enrolls, "EnrollId", "EnrollId", installment.EnrollmentId);
            return View(installment);
        }

        //
        // GET: /Installment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Installment installment = db.Installments.Find(id);
            if (installment == null)
            {
                return HttpNotFound();
            }
            return View(installment);
        }

        //
        // POST: /Installment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Installment installment = db.Installments.Find(id);
            db.Installments.Remove(installment);
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