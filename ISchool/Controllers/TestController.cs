using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISchool.Models;


namespace ISchool.Controllers
{
    public class TestController : Controller
    {
        ISchoolEntities db = new ISchoolEntities();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult phieutheodoi()
        {
            var result = from sv in db.Sinhviens
                         from gv in db.Giangviens
                         from pgdt in db.Phieugiaodetais
                         from pdt in db.Phieutheodois
                         from dt in db.Detais

                         where sv.MASV == pgdt.MASV
                         where gv.MAGV == pgdt.MAGV
                         where pdt.SoPGDT == pgdt.SoPGDT
                         where dt.MADT == pgdt.MADT
                         select new
                         {
                             tensv = sv.TENSV,
                             tendt = dt.TENDT,
                             diem = pdt.DIEM_THEODOI
                         };
            return View(result);
        }
    }
}