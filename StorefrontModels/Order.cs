using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class Order{
        private Dictionary<string, int> _items;
        private string _location;
        private double totalPrice;
        public Order(){}
        public double TotalPrice { get; set; }
        public string Location { get; set; }
        public Dictionary Items {get; set;}
    }
        

}