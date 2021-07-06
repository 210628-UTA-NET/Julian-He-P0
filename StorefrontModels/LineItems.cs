using System;
using System.Collections.Generic;

namespace StorefrontModels
{
    public class LineItem{
        private int _quantity;
        private string _productName;
        public LineItem(){
        }
        public int Quantity{
                get{
                    return _quantity;
                }
                set{
                    _quantity = value;
                }
            }
        public string ProductName{
            get{
                return _productName;
            }
            set{
                _productName = value;
            }
        }
    }
}