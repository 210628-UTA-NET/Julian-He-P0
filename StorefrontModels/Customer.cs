using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class Customer
    {
        private string _name;
        private string _address;
        private List<T> _orders = new List<T>();
        private string _emailPhone;
        public Customer(){

        }
        public string Name { 
            get
            {
                return _name;
            } 
            set
            {
                _name= value;
            } 
        }
        public string Address { 
            get{
                return _Address;
            } 
            set{
                _address=value;
            }
             }
        public List<T> Orders { 
            get{
                return _orders;
            } 
            set{
                _orders.Add(value);
            } 
        }
        public string EmailPhone { get
        {return _emailPhone;} 
        set{
            _emailPhone = value;
        } 
        }
    }
}
