using MultiLingual_Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MultiLingual_Form.Controllers
{
    public class HomeController : MyController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.LanguageCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Registration r)
        {
            return View(r);
        }
       
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageManage().SetLanguage(lang);
            return RedirectToAction("Index", "Home");
        }
    }
}