using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Printing;

namespace EdithTour.Controllers
{
    public class ShoppingCartController : Controller
    {
        private EdithTourEntities db = new EdithTourEntities();
        // GET: ShoppingCart
        
        public ActionResult Index()
        {
            //var select = new Cart().select_cart();
            //ViewBag.Index = select;
            //return View(select);
            List<Tour_Inside> inside= db.Tour_Inside.ToList();
            return View(inside);
        }
        
        
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }
        public ActionResult AddtoCart(int ID)
        {
            var inside = db.Tour_Inside.SingleOrDefault(s => s.ID_tour_inside == ID);
            if (inside != null)
            {
                GetCart().Add(inside);
            }

            return RedirectToAction("Show", "ShoppingCart");

        }
        public ActionResult Show()
        {         
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Show", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id = int.Parse(form["ID_tour_inside"]);

            int quantity = int.Parse(form["Quantity"]);
           
            cart.Update_Quanlity_Shopping(id, quantity);
            return RedirectToAction("Show", "ShoppingCart");
        }



    }

}
