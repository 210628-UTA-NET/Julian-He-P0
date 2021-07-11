using System;
using StorefrontModels;
using System.Threading;
using System.Collections.Generic;

namespace StorefrontUI{
    public class OrderMaker{
    public OrderMaker(){

    }
    public Order MakeOrder(){
        Console.WriteLine("This is the Order Maker");
        bool order = true;
        Order customerorder = new Order(); 
        List<LineItem> orderlist = new List<LineItem>();
        while(order){
            Console.WriteLine("What would you like to add first?");
            Console.WriteLine("[1] Order Location:" + customerorder.Location);
            Console.WriteLine("[2] Product List: " + Convert.ToString(customerorder.Items));
            Console.WriteLine("[0] Finish");
            string input = Console.ReadLine();
            if (input == "1"){
                Console.WriteLine("Please enter the Location the order was placed");
                customerorder.Location = Console.ReadLine();
            }
            if (input== "2"){
                LineItem newItem = new LineItem();
                bool run = true;
                while(true){
                Console.WriteLine("What is the Product you want to add");
                ProductMaker maker = new ProductMaker();
                Product item = maker.MakeProduct();
                newItem.ProductName = item;
                Console.WriteLine("How many of this product do you have?");
                try{
                newItem.Quantity = Convert.ToInt32(Console.ReadLine());
                    }
                catch{
                    Console.WriteLine("Cannot have decimals or Letters");
                }
                customerorder.Items.Add(newItem);
                Console.WriteLine("Would you like to add another item to the order?");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No");
                string cont = Console.ReadLine();
                if (cont == "2"){
                    run=false;
                }

                }
            }
            if (input == "0"){
                order = false;
            }
        }
        return customerorder;
    }
    }
}