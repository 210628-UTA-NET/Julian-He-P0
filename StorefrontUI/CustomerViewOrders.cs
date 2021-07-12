using StorefrontBL;
using StorefrontModels;
using System.Collections.Generic;
using System;

namespace StorefrontUI{
    
    public class CustomerViewOrders : ISelectionPage{
        private ICustomerBL _CustomerBL;

        public CustomerViewOrders(ICustomerBL p_CustomerBL){
                _CustomerBL = p_CustomerBL;
            }

        public void Page()
        {
            Customer Customertosee;
            List<Customer> Customers = _CustomerBL.GetAllCustomers();
            Console.WriteLine("All Available Customers");
            int i = 0;
            foreach(Customer Customer in Customers){
                Console.WriteLine("["+i+"] " + Customer.Name + " with address " + Customer.Address);
                i++;
            }
            Console.WriteLine("Which Customer would you like to choose?");
            string choice = Console.ReadLine();
            Customertosee = Customers[Convert.ToInt32(choice)];
            List<Order> orderlist = Customertosee.Orders;
            foreach (Order order in orderlist){
                Console.WriteLine(order.OrderID + "  " + order.TotalPrice);
            }
            Console.WriteLine("[0] Return to Customer Options");
            Console.WriteLine("[1] View another Customer's orders");
        }

        public PageType Selection(){
            string choice = Console.ReadLine();
            switch(choice){
                case "0":
                    return PageType.CustomerOptions;
                case "1":
                    return PageType.CustomerViewOrders;
                default:
                    return PageType.CustomerViewOrders;
            }
        }    
    }

}