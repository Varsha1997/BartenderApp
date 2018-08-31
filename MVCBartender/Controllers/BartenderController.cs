using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBartender.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MVCBartender.Controllers
{
    public class BartenderController : Controller
    {
        // GET: Bartender
        public ActionResult Index()
        {
            BartenderDBhandle dbhandle = new BartenderDBhandle();
            ModelState.Clear();
            return View(dbhandle.GetBartender());
        }


        // GET: Bartender/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bartender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bartender/Create
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

        // GET: Bartender/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bartender/Edit/5
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

        // GET: Bartender/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bartender/Delete/5
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
