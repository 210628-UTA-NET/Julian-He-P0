using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class Storefront
    {
        private string _name;
        private string _address;
        private List<LineItem> _inventory;
        private List<Order> _orders;

        public Storefront(){
           
        }
        public string Name { 
            get{ 
                return _name;
                } 
            set{ 
                _name=value;
                } 
            }

        public string Address { 
            get{return _address;}
        
            set{_address = value;} 
         }
         public List<LineItem> Inventory{


             get{
                 return _inventory;
                 }
             
             private set{
                 _inventory = value;
             }
        }
        public List<Order> Orders { get{
            return _orders;
        } private set{
            _orders= value;
        } }

    }
}
