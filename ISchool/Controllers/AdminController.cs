﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISchool.Models;

namespace ISchool.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ISchoolEntities db = new ISchoolEntities();
        public ActionResult Index()
        {
            return View(db.Nguoidungs.ToList());
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
                    Session["TENND"] = obj.TENND.ToString();
                    return RedirectToAction("demoMatrixAdminLayout","Home");
                }
            }
            return View(objUser);
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

        //test layout
        public ActionResult testAdminLayout()
        {
            return View();
        }


    }
}