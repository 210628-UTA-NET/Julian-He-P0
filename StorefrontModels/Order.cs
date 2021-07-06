using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class Order{
        private List<LineItem> _items;
        private string _location;
        private double _totalPrice;
        public Order(){}
        public double TotalPrice { get{
            return  _totalPrice;
        } set{
            _totalPrice = value;
        } }
        public string Location { get{
            return _location;
        } set{
            _location = value;
        } }
        public List<LineItem> Items {get{
            return _items;
        } set{
            _items=value;
        }}
    }
        

}