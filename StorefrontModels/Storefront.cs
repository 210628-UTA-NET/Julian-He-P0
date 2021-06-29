using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class Storefront
    {
        private string _name;
        private string _address;
        private Dictionary<string, int> _inventory;
        private List<Order> _orders;

        public Storefront(){
           
        }
        public string Name { get; set; }
    }
}