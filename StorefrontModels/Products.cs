using System;

namespace StorefrontModels{
    public class Product{
        private string _name;
        private double _price;
        private string _desc = "No description found";
        private string _category = "No category set";

        public Product(){

        }
        public string Name { 
            get{
            return _name;
            } 
            set{
            _name = value;
            } 
        }

        public double Price{
            get{
                return _price;
            }
            set{
                _price=value;
            }
        }
        public string Desc{
            get{
                return _desc;
            }
            set{
                _desc=value;
            }
        }
        public string Category{
            get{
                return _category;
            }
            set{
                _category = value;
            }
        }

    }
}