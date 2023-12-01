﻿using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private EdithTourEntities db = new EdithTourEntities();
        public ActionResult Index()
        {
            List<Tourtrending> trending = db.Tourtrending.ToList();
            List<Locations> locations = db.Locations.ToList();
            List<Tour> tour = db.Tour.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.Trending = trending;
            mymodel.Locations = locations;
            mymodel.Tour = tour;
            return View(mymodel);
        }

        public ActionResult Policy()
        {
            return View();
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Introduction()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult Danang()
        {

            return View();
        }
        public ActionResult Quangbinh()
        {
            return View();
        }

        public ActionResult Hanoi()
        {
            return View();
        }
        public ActionResult Nhatrang()
        {
            return View();
        }
        public ActionResult Phuquoc()
        {
            return View();
        }
    }
}