using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EdithTour.Models
{
    public class CartView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name_Ticket { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> amount { get; set; }
    }
    
}