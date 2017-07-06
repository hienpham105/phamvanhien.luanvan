using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISchool.Models;

namespace ISchool.Controllers
{
    public class HomeController : Controller
    {
        ISchoolEntities db = new ISchoolEntities();

        public ActionResult Dashbroad()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Nguoidung objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Nguoidungs.Where(a => a.TENND.Equals(objUser.TENND) && a.MATKHAU.Equals(objUser.MATKHAU)).FirstOrDefault();
                if (obj != null)
                {
                    Session["MAND"] = obj.MAND.ToString();
                    Session["TENDN"] = obj.TENND.ToString();
                    return RedirectToAction("Dashbroad");
                }
            }
            return View(objUser);
        }

        //Logout
        public ActionResult Logout()
        {
            Session["MAND"] = null;
            return new RedirectResult("Login");
        }
        public ActionResult UserDashBoard()
        {
            if (Session["MAND"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //get try login
        public ActionResult Login_v02()
        {
            return View();
        }
    }
}