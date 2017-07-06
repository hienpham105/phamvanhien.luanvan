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
    public class GiangvienController : Controller
    {
        private ISchoolEntities db = new ISchoolEntities();

        // GET: Giangvien
        public ActionResult DanhsachGiangvien(int? page)
        {
            var count = 0;
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            var giangviens = db.Giangviens.Include(g => g.Chucvu).Include(g => g.Chuyennganh).
                Include(g => g.Donvi).Include(g => g.Hocvi);
            count = giangviens.ToList().Count;
            return View(giangviens.ToList().OrderByDescending(n => n.CreateDate).ToPagedList(pageNumber, pageSize));
            
        }

        // GET: Giangvien/Details/5
        public ActionResult Chitiet(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }
        [HttpGet]
        // GET: Giangvien/Create
        public ActionResult Themmoi()
        {
            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV");
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN");
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV");
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV");
            return View();
        }

        // POST: Giangvien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Themmoi(Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Giangviens.Add(giangvien);
                db.SaveChanges();
                return RedirectToAction("DanhsachGiangvien", "Giangvien");
            }

            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV", giangvien.MACV);
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", giangvien.MACN);
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV", giangvien.MADV);
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV", giangvien.MAHV);
            return View(giangvien);
        }

        // GET: Giangvien/Edit/5
        [HttpGet]
        public ActionResult Sua(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV", giangvien.MACV);
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", giangvien.MACN);
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV", giangvien.MADV);
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV", giangvien.MAHV);
            return View(giangvien);
        }

        // POST: Giangvien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Sua(Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhsachGiangvien","Giangvien");
            }
            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV", giangvien.MACV);
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", giangvien.MACN);
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV", giangvien.MADV);
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV", giangvien.MAHV);
            return View(giangvien);
        }

        // GET: Giangvien/Delete/5
        public ActionResult Xoa(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // POST: Giangvien/Delete/5
        [HttpPost, ActionName("Xoa")]
        public ActionResult DeleteConfirmed(string id)
        {
            Giangvien giangvien = db.Giangviens.Find(id);
            db.Giangviens.Remove(giangvien);
            db.SaveChanges();
            return RedirectToAction("DanhsachGiangvien");
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
