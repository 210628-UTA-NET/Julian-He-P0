using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StorefrontModels
{
    public class LineItem{
        private int _quantity;
        private Product _product;
        public LineItem(){
        }
        public int Quantity{
                get{
                    return _quantity;
                }
                set{
                    if (value <0){
                        throw new Exception("Quantity cannot be less than 0");
                    }
                    else{
                    
                    _quantity = value;
                    }
                }
            }
        public Product ProductName{
            get{
                return _product;
            }
            set{
                _product = value;
            }
        }
    }
}