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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
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
				if (l.Password == "admin123")
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

		// GET: Admin/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
