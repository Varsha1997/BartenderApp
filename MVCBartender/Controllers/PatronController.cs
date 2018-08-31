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
    public class PatronController : Controller
    {
     
        public ActionResult Index()
        {
            PatronDBhandle dbhandle = new PatronDBhandle();
            ModelState.Clear();
            return View(dbhandle.GetPatron());
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Menu()
        {
            MenuDBhandle dbhandle = new MenuDBhandle();
            ModelState.Clear();
            return View(dbhandle.GetMenu());
        }


        public ActionResult Add()
        {
            return View();
        }

        // Post the info
        [HttpPost]
        public ActionResult Add(PatronModel pmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatronDBhandle pdb = new PatronDBhandle();
                    if (pdb.AddPatron(pmodel))
                    {
                        ViewBag.Message = "User Details Added Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        // Post info
        [HttpPost]
        public ActionResult Register(PatronModel pmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatronDBhandle sdb = new PatronDBhandle();
                    if (sdb.AddPatron(pmodel))
                    {
                        ViewBag.Message = "User Details Added Successfully";
                        ModelState.Clear();
                        return RedirectToAction("ThankYou");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }




       
        public ActionResult Edit(int id)
        {
            PatronDBhandle sdb = new PatronDBhandle();
            return View(sdb.GetPatron().Find(pmodel => pmodel.Id == id));
        }

        // post info
        [HttpPost]
        public ActionResult Edit(int id, PatronModel pmodel)
        {
            try
            {
                PatronDBhandle pdb = new PatronDBhandle();
                pdb.UpdatePatronDetails(pmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            try
            {
                PatronDBhandle pdb = new PatronDBhandle();
                if (pdb.DeletePatron(id))
                {
                    ViewBag.AlertMsg = "User Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Admin()
        {
            return View();
        }

    }
    }

