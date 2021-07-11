using StorefrontModels;
using System;
using System.Collections.Generic;
using StorefrontBL;
namespace StorefrontUI{

    public class CustomerOptions : ISelectionPage{
        
        private Customer _targetCustomer; 
        private ICustomerBL _storeBL;
        public CustomerOptions(Customer customer, ICustomerBL p_storeBL){
            _targetCustomer = customer;
            _storeBL = p_storeBL;
        }

        public void Page()
        {
            Console.WriteLine("Welcome to " +_targetCustomer.Name+ "'s page, what would you like to do?");
            Console.WriteLine("[1] View Orders");
            Console.WriteLine("[2] Place an Order");
            Console.WriteLine("[3] Find a different customer");
        }

        public PageType Selection()
        {
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    List<Order> orderlist = _targetCustomer.Orders;
                    Console.WriteLine("Which order would you like to see");
                    foreach (Order order in orderlist){
                        List<LineItem> orderitems = order.Items;
                        foreach(LineItem lineitem in orderitems){
                            Console.WriteLine(lineitem.ProductName.Name );
                        }
                    }

                    return PageType.CustomerOptions;
                case "2":
                    MakeOrder PlaceOrder = new MakeOrder(_targetCustomer, _storeBL);
                    PlaceOrder.Page();
                    PageType page = PlaceOrder.Selection();
                    return page;
                case "3":
                    Console.WriteLine("Returning to Customer Search Page");
                    Console.Clear();
                    return PageType.FindCustomerPage;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return PageType.CustomerOptions;
            }
            
        }
    }
}