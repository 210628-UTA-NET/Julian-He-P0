using StorefrontBL;
using StorefrontDL;
using StorefrontModels;
using System.Collections.Generic;
using System;

namespace StorefrontUI{
    
    public class CustomerViewOrders : ISelectionPage{
        private ICustomerBL _CustomerBL;
private StorefrontDL.Entities.P0DBContext _context;
        public CustomerViewOrders(ICustomerBL p_CustomerBL, StorefrontDL.Entities.P0DBContext context){
                _CustomerBL = p_CustomerBL;
                _context = context;
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
            OrderBL orders = new OrderBL(new OrderRepository(new StorefrontDL.Entities.P0DBContext()));
            List<Order> orderlist = orders.GetCustomerOrder(Customertosee.ID);
            Console.WriteLine("Order ID Number     Total Cost");
            foreach (Order order in orderlist){

                Console.WriteLine(order.OrderID + "                   " + order.TotalPrice);
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