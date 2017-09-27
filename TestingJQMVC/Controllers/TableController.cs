using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingJQMVC.Models;

namespace TestingJQMVC.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (PupilContext db = new PupilContext())
            {
                var WorkerData = db.ViewModels.OrderBy(a => a.Name).ToList();
                return Json(new { data = WorkerData }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}