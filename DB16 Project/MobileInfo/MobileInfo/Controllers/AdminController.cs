using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileInfo.Models;

namespace MobileInfo.Controllers
{
    public class AdminController : Controller
    {
        private DB16Entities db = new DB16Entities();
		SqlConnection con = new SqlConnection(@"Data Source = HAIER - PC\SQLEXPRESS; Initial Catalog = ProjectA; Integrated Security = True");
		SqlConnection con1 = new SqlConnection(@"Data Source =HAIER-PC\SQLEXPRESS;initial catalog = DB16; integrated security = True");
		public ActionResult BIndex()
		{
			using (DB16Entities db = new DB16Entities())
			{
				return View(db.Brands.ToList());
			}

		}

		[HttpGet]
		public ActionResult AdminLogin()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AdminLogin(Administrator l)
		{
			if (l.Email == "admin123@gmail.com")
			{
				if (l.Password == "1")
				{
					return RedirectToAction("ALoggedIn");
				}
				else
				{
					TempData["msg"] = "<script>alert('Login Failed');</script>";
				}
			}
			else
			{
				TempData["msg"] = "<script>alert('Login Failed');</script>";
			}
			return RedirectToAction("AdminLogin");
		}

		public ActionResult ALoggedIn()
		{
			return View();
		}

    }
}
