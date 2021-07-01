using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class Order{
        private List<LineItem> _items;
        private string _location;
        private double totalPrice;
        public Order(){}
        public double TotalPrice { get; set; }
        public string Location { get; set; }
        public List<LineItem> Items {get{
            return _items;
        } set{
            _items=value;
        }}
    }
        

}