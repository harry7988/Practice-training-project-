using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHSS.Models;


namespace EHSS.Controllers
{
    public class HomeController : Controller
    {
        HESSLocalDBEntities db = new HESSLocalDBEntities();
        public ActionResult Index()
        {
            Response.Write(User.Identity.Name);
            return View();
        }

        public ActionResult Approve()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}