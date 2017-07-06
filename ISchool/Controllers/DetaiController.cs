using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISchool.Models;
using PagedList;
using PagedList.Mvc;

namespace ISchool.Controllers
{
    public class DetaiController : Controller
    {
        private ISchoolEntities db = new ISchoolEntities();

        // GET: Detai
        public ActionResult DanhsachDeTai(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            var detais = db.Detais.Include(d => d.LoaiDT);
            int sodt = detais.ToList().Count();
            
            return View(detais.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Detai/Details/5
        public ActionResult Chitiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detai detai = db.Detais.Find(id);
            if (detai == null)
            {
                return HttpNotFound();
            }
            return View(detai);
        }

        // GET: Detai/Create
        [HttpGet]
        public ActionResult Themmoi()
        {
            ViewBag.MALDT = new SelectList(db.LoaiDTs, "MALDT", "TENLDT");
            return View();
        }
        
        [HttpPost]
        public ActionResult Themmoi(Detai detai)
        {
            if (ModelState.IsValid)
            {
                db.Detais.Add(detai);
                db.SaveChanges();
                return RedirectToAction("DanhsachDeTai", "Detai");
            }

            ViewBag.MALDT = new SelectList(db.LoaiDTs, "MALDT", "TENLDT", detai.MALDT);
            return View(detai);
        }

        [HttpGet]
        // GET: Detai/Edit/5
        public ActionResult Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detai detai = db.Detais.Find(id);
            if (detai == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALDT = new SelectList(db.LoaiDTs, "MALDT", "TENLDT", detai.MALDT);
            return View(detai);
        }

        // POST: Detai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Sua(Detai detai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhsachDetai");
            }
            ViewBag.MALDT = new SelectList(db.LoaiDTs, "MALDT", "TENLDT", detai.MALDT);
            return View(detai);
        }

        // GET: Detai/Delete/5
        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detai detai = db.Detais.Find(id);
            if (detai == null)
            {
                return HttpNotFound();
            }
            return View(detai);
        }

        // POST: Detai/Delete/5
        [HttpPost, ActionName("Xoa")]
        public ActionResult DeleteConfirmed(int id)
        {
            Detai detai = db.Detais.Find(id);
            db.Detais.Remove(detai);
            db.SaveChanges();
            return RedirectToAction("DanhsachDetai","Detai");
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
