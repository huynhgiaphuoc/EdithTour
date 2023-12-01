﻿using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private EdithTourEntities db = new EdithTourEntities();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login","Account", new {area = ""});
        }

        public ActionResult Users(string search = " ")
        {
            List<Customer> customers = db.Customer.Where(row => row.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(customers);
        }

        public ActionResult Edit(int id) {
            Customer cus = db.Customer.Where(row => row.ID_customer == id).FirstOrDefault();
            return View(cus);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer, int ID_customer)
        {
            Customer customers = db.Customer.Where(row => row.ID_customer == ID_customer).FirstOrDefault();
            if(customers != null)
            {

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Customer cus = db.Customer.Where(row => row.ID_customer == id).FirstOrDefault();
            return View(cus);
        }

        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            Customer cus = db.Customer.Where(row => row.ID_customer == id).FirstOrDefault();
            db.Customer.Remove(cus);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

    }
}