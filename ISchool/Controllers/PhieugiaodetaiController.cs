using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISchool.Models;

namespace ISchool.Controllers
{
    public class PhieugiaodetaiController : Controller
    {
        private ISchoolEntities db = new ISchoolEntities();

        // GET: Phieugiaodetai
        public ActionResult Index()
        {
            var phieugiaodetais = db.Phieugiaodetais.Include(p => p.Sinhvien).Include(p => p.Detai).Include(p => p.Giangvien);
            return View(phieugiaodetais.ToList());
        }

        // GET: Phieugiaodetai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieugiaodetai phieugiaodetai = db.Phieugiaodetais.Find(id);
            if (phieugiaodetai == null)
            {
                return HttpNotFound();
            }
            return View(phieugiaodetai);
        }

        // GET: Phieugiaodetai/Create
        public ActionResult Create()
        {
            ViewBag.MASV = new SelectList(db.Sinhviens, "MASV", "HOSV");
            ViewBag.MADT = new SelectList(db.Detais, "MADT", "TENDT");
            ViewBag.MAGV = new SelectList(db.Giangviens, "MAGV", "HOGV");
            return View();
        }

        // POST: Phieugiaodetai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPGDT,Ngaygiao,Hannop,MASV,MADT,MAGV")] Phieugiaodetai phieugiaodetai)
        {
            if (ModelState.IsValid)
            {
                db.Phieugiaodetais.Add(phieugiaodetai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MASV = new SelectList(db.Sinhviens, "MASV", "HOSV", phieugiaodetai.MASV);
            ViewBag.MADT = new SelectList(db.Detais, "MADT", "TENDT", phieugiaodetai.MADT);
            ViewBag.MAGV = new SelectList(db.Giangviens, "MAGV", "HOGV", phieugiaodetai.MAGV);
            return View(phieugiaodetai);
        }

        // GET: Phieugiaodetai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieugiaodetai phieugiaodetai = db.Phieugiaodetais.Find(id);
            if (phieugiaodetai == null)
            {
                return HttpNotFound();
            }
            ViewBag.MASV = new SelectList(db.Sinhviens, "MASV", "HOSV", phieugiaodetai.MASV);
            ViewBag.MADT = new SelectList(db.Detais, "MADT", "TENDT", phieugiaodetai.MADT);
            ViewBag.MAGV = new SelectList(db.Giangviens, "MAGV", "HOGV", phieugiaodetai.MAGV);
            return View(phieugiaodetai);
        }

        // POST: Phieugiaodetai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPGDT,Ngaygiao,Hannop,MASV,MADT,MAGV")] Phieugiaodetai phieugiaodetai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieugiaodetai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MASV = new SelectList(db.Sinhviens, "MASV", "HOSV", phieugiaodetai.MASV);
            ViewBag.MADT = new SelectList(db.Detais, "MADT", "TENDT", phieugiaodetai.MADT);
            ViewBag.MAGV = new SelectList(db.Giangviens, "MAGV", "HOGV", phieugiaodetai.MAGV);
            return View(phieugiaodetai);
        }

        // GET: Phieugiaodetai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieugiaodetai phieugiaodetai = db.Phieugiaodetais.Find(id);
            if (phieugiaodetai == null)
            {
                return HttpNotFound();
            }
            return View(phieugiaodetai);
        }

        // POST: Phieugiaodetai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phieugiaodetai phieugiaodetai = db.Phieugiaodetais.Find(id);
            db.Phieugiaodetais.Remove(phieugiaodetai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
