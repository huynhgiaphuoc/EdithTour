using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace EdithTour.Models
{


    public class cart_item
    {
        public Tour_Inside inside { get; set; }
        public decimal? quanlity { get; set; }
    }

    public class Cart
    {
        List<cart_item> items = new List<cart_item>();
        public IEnumerable<cart_item> Items
        {
            get { return items; }
        }



        public void Add(Tour_Inside inside, int ql = 1)
        {
            var item = items.FirstOrDefault(s => s.inside.ID_tour_inside == inside.ID_tour_inside);
            if (item == null)
            {
                items.Add(item = new cart_item
                {
                    inside = inside,
                    quanlity = ql
                });
            }
            else { item.quanlity += ql; }

        }
        public void Update_Quanlity_Shopping(int id, int quantity)
        {
            var item = items.Find(s => s.inside.ID_tour_inside == id);
            if (item != null)
            {
                item.quanlity = quantity;
            }
        }


        public List<Ticket> select_cart()
        {
            var model = db.Ticket.ToList();

            //var name= model.FirstOrDefault().Name;
            //var price = db.Ticket.FirstOrDefault(s => s.Name == name);
            //if (price != null)
            //{
            // price.Price = model.FirstOrDefault().Price;
            //}
            return model;
        }
        public List<Ticket> select_price(string Name, decimal Price)
        {


            var price = db.Ticket.Where(Ticket => Ticket.Name.Equals(Name)).FirstOrDefault();
            if (price != null)
            {
                price.Price = Price;
            }
            return select_price(Name, Price);
        }
        public EdithTourEntities db = new EdithTourEntities();
        public decimal? Total_money()
        {
            var money = items.Sum(s => s.quanlity * s.inside.Price);
            return (decimal)money;
        }
    }


        //public List<Ticket> select_price(string name)
        //{
        //    var model = db.Ticket.Where(s=>s.Name==name);
        //   if(model != null)
        //    {
        //        decimal? price = model.FirstOrDefault().Price;
        //    }
        //    return select_price(name);
        //}
        //public EdithTourEntities db = new EdithTourEntities();
        //public List<CartView> select_cart()
        //{
        //    var model = (from a in db.Tour_Inside
        //                 join b in db.Ticket on a.ID_tour_inside equals b.ID_tour_inside
        //                 where a.ID_tour_inside < 100
        //                 select new CartView()
        //                 {
        //                     Id = a.ID_tour_inside,
        //                     Name = a.Name,
        //                     Description = a.Description,
        //                     Image = a.Image,
        //                     Name_Ticket = b.Name,
        //                     Price = b.Price,
        //                     amount = b.Numberof_ticket,
        //                 }).ToList();
        //    return model;
        //}
    }


    
