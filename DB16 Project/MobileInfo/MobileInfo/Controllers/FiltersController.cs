using MobileInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileInfo.Controllers
{
    public class FiltersController : Controller
    {
        private DB16Entities db = new DB16Entities();

        // GET: Filters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Price50000( )
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Screen3to4()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult RAM4GB()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Cam12to16()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

    }
}