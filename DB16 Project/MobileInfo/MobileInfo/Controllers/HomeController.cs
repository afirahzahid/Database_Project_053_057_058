using MobileInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace MobileInfo.Controllers
{
    public class HomeController : Controller
    {

        private DB16Entities db = new DB16Entities();

        public ActionResult Index()
        {
            var entities = new DB16Entities();
            return View(entities.Brands.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult blah()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BrandMobiles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.linkableId = id;
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }


        public ActionResult MobileDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.linkableId = id;
            Mobile mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return HttpNotFound();
            }

            return View(mobile);
        }


        public ActionResult MobilePictures(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.linkableId = id;
            var entities = new DB16Entities();
            return View(entities.Pictures.ToList());
        }


        public ActionResult MobileReviews(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.linkableId = id;
            var entities = new DB16Entities();
            return View(entities.Reviews.ToList());
        }


        [HttpGet]
        public ActionResult GiveReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.linkableId = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GiveReview(Review r, int? idp)
        {
            if (ModelState.IsValid)
            {
                r.MobileId = (int)idp;
                db.Reviews.Add(r);
                db.SaveChanges();
                ModelState.Clear();
                r = null;
                ViewBag.Message = "Submitted";
                return RedirectToAction("MobileDetails", "Home", new { id = idp});                
            }
            return View(r);
        }
    }
}
