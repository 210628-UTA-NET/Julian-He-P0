using StorefrontModels;
using System;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontDL;
namespace StorefrontUI{

    public class CustomerOptions : ISelectionPage{
        
        private ICustomerBL _customerBL;
        private StorefrontDL.Entities.P0DBContext _context;
        public CustomerOptions(ICustomerBL p_customerBL, StorefrontDL.Entities.P0DBContext context){

            _customerBL = p_customerBL;
            _context = context;
        }

        public void Page()
        {
            Console.WriteLine("Welcome to Customer Options page, what would you like to do?");
            Console.WriteLine("[1] View Orders");
            Console.WriteLine("[2] Place an Order");
            Console.WriteLine("[3] Return to customer page");
        }

        public PageType Selection()
        {
            string input = Console.ReadLine();
            switch(input){
                case "1":
/*                     List<Order> orderlist = _targetCustomer.Orders;
                    Console.WriteLine("Which order would you like to see");
                    foreach (Order order in orderlist){
                        Console.WriteLine(order);
                        List<LineItem> orderitems = order.Items;
                        foreach(LineItem lineitem in orderitems){
                            Console.WriteLine(lineitem.ProductName.Name);
                        }
                    } */

                    return PageType.CustomerViewOrders;
                case "2":
                    Console.WriteLine("List of Customers");
                    List<Customer> customers = _customerBL.GetAllCustomers();
                    Customer finalcustomer = new Customer();
                    int i = 0;
                    foreach (Customer customer in customers){
                        Console.WriteLine("============================");
                        Console.WriteLine("[{0}]" + customer.Name, i);
                        Console.WriteLine("============================");
                        i++;
                        }
                    bool customerselected = false;    
                    while(!customerselected){
                    Console.WriteLine("What is the number of the Customer who wishes to make an order");
                    string num = Console.ReadLine();
                    int CustomerNum = Convert.ToInt32(num);
                    if (CustomerNum > customers.Count){
                        Console.WriteLine("Customer number not found");
                    }
                    else{
                        finalcustomer = customers[CustomerNum];
                        customerselected= true;
                    }}
                    MakeOrder PlaceOrder = new MakeOrder(finalcustomer, _customerBL, new StoreBL(new StoreRepository(_context)), _context);
                    PlaceOrder.Page();
                    PageType page = PlaceOrder.Selection();
                    return page;
                case "3":
                    Console.WriteLine("Returning to Customer Page");
                    Console.Clear();
                    return PageType.CustomerPage;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return PageType.CustomerOptions;
            }
            
        }
    }
}