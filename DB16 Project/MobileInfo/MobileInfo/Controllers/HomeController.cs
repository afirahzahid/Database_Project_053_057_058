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

        public ActionResult Price200()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Price150to199()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Price100to149()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Price50to99()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Price50()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult RAM16GB()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult RAM8GB()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult RAM6GB()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult RAM4GB()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult RAMLess4GB()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult ScreenLess4()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Screen4to5()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Screen5to6()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Screen6to7()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Screen7to8()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult CamLess8()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Cam8to12()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Cam13to16()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }


        public ActionResult Cam17to24()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }

        public ActionResult Cam25to40()
        {
            var entities = new DB16Entities();
            return View(entities.Mobiles.ToList());
        }



    }
}
