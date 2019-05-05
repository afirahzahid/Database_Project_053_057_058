using MobileInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data;

namespace MobileInfo.Controllers { 

    public class HomeController : Controller
    {
        private DB16Entities db = new DB16Entities();
        SqlConnection con1 = new SqlConnection(@"Data Source = DESKTOP-QK3I2UN\SQLEXPRESS; initial catalog = DB16; integrated security = True");

		public ActionResult Index()
        {
            var entities = new DB16Entities();
            return View(entities.Brands.ToList());
        }

		public ActionResult SearchIndex(string searching)
		{

			return View(db.Mobiles.Where(x => x.Name.Contains(searching) || searching == null).ToList());
		}

		public ActionResult SearchingDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Mobile m = db.Mobiles.Find(id);
			return View(m);
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
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }

            string que = "SELECT [Name] From Brands WHERE Brands.Id = @param";
            SqlCommand cmd = new SqlCommand(que, con1);
            cmd.Parameters.AddWithValue("param", id);
            string brandname = cmd.ExecuteScalar().ToString();

            string que1 = "SELECT [Description] From Brands WHERE Brands.Id = @param1";
            SqlCommand cmd1 = new SqlCommand(que1, con1);
            cmd1.Parameters.AddWithValue("param1", id);
            string branddesc = cmd1.ExecuteScalar().ToString();

            ViewBag.linkablename = brandname;
            ViewBag.linkabledesc = branddesc;
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

            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }

            string que = "SELECT [Name] From Mobile WHERE Mobile.Id = @param";
            SqlCommand cmd = new SqlCommand(que, con1);
            cmd.Parameters.AddWithValue("param", id);
            string mobilename = cmd.ExecuteScalar().ToString();

            ViewBag.linkablename = mobilename;
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

            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }

            string que = "SELECT [Name] From Mobile WHERE Mobile.Id = @param";
            SqlCommand cmd = new SqlCommand(que, con1);
            cmd.Parameters.AddWithValue("param", id);
            string mobilename = cmd.ExecuteScalar().ToString();

            ViewBag.linkablename = mobilename;
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
                r.RDate = DateTime.Today;
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

        public ActionResult Report1()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd1;
            string display = "SELECT Name, Price FROM Mobile AS M1 WHERE M1.Price = (SELECT MAX(M2.Price) FROM Mobile AS M2 WHERE M1.BrandId = M2.BrandId)";
            cmd1 = new SqlCommand(display, con1);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable nummobilesdt = new DataTable();
            sda.Fill(nummobilesdt);

            rd.SetDataSource(nummobilesdt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application.pdf", "HighestPricedMobiles.pdf");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Report2()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd1;
            string display = "SELECT Name, Price FROM Mobile AS M1 WHERE M1.Price = (SELECT MIN(M2.Price) FROM Mobile AS M2 WHERE M1.BrandId = M2.BrandId)";
            cmd1 = new SqlCommand(display, con1);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable nummobilesdt = new DataTable();
            sda.Fill(nummobilesdt);

            rd.SetDataSource(nummobilesdt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application.pdf", "LowestPricedMobiles.pdf");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Report3()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport3.rpt"));
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd1;
            DateTime dt = DateTime.Now;
            string display = "SELECT Name, OS, Size, Price FROM Mobile WHERE Month([Announced On]) = @param AND Year([Announced On]) = @param1";
            cmd1 = new SqlCommand(display, con1);
            cmd1.Parameters.AddWithValue("@param", dt.Month);
            cmd1.Parameters.AddWithValue("@param1", dt.Year);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable nummobilesdt = new DataTable();
            sda.Fill(nummobilesdt);

            rd.SetDataSource(nummobilesdt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application.pdf", "CurrentMonthReleasedMobiles.pdf");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Report4()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport4.rpt"));
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd1;
            string display = "SELECT Name, OS, Size, Price FROM Mobile WHERE Price > @param1";
            cmd1 = new SqlCommand(display, con1);
            cmd1.Parameters.AddWithValue("@param1", 100000);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable nummobilesdt = new DataTable();
            sda.Fill(nummobilesdt);

            rd.SetDataSource(nummobilesdt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application.pdf", "Greater100kMobiles.pdf");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Report5()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport5.rpt"));
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd1;
            string display = "SELECT Name, OS, Size, Price FROM Mobile WHERE Price > @param1";
            cmd1 = new SqlCommand(display, con1);
            cmd1.Parameters.AddWithValue("@param1", 50000);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable nummobilesdt = new DataTable();
            sda.Fill(nummobilesdt);

            rd.SetDataSource(nummobilesdt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application.pdf", "Greater50kMobiles.pdf");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Report6()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport6.rpt"));
            if (con1.State == System.Data.ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd1;
            string display = "SELECT Name, OS, Size, Price FROM Mobile WHERE Price < @param1";
            cmd1 = new SqlCommand(display, con1);
            cmd1.Parameters.AddWithValue("@param1", 50000);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable nummobilesdt = new DataTable();
            sda.Fill(nummobilesdt);

            rd.SetDataSource(nummobilesdt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application.pdf", "Below50kMobiles.pdf");
            }
            catch
            {
                throw;
            }
        }
    }
}
