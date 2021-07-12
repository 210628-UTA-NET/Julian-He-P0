using StorefrontModels;
using System;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontDL;
namespace StorefrontUI{

    public class CustomerOptions : ISelectionPage{
        
        private ICustomerBL _customerBL;
        public CustomerOptions(ICustomerBL p_customerBL){

            _customerBL = p_customerBL;
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
                    foreach (Customer customer in customers){
                        Console.WriteLine("============================");
                        Console.WriteLine(customer.Name);
                        Console.WriteLine("============================");
                        }
                    bool customerselected = false;    
                    while(customerselected){
                    Console.WriteLine("What is the name of the Customer who wishes to make an order");
                    List<Customer> chosen = new List<Customer>();
                    string CustomerName = Console.ReadLine();
                    foreach(Customer customer1 in customers){
                        if (customer1.Name == CustomerName){
                            chosen.Add(customer1);
                        }
                    }
                    if (chosen.Count >1){
                        Console.WriteLine("Multiple people with this name found please select one");
                        int i = 1;
                        foreach(Customer customer in chosen){
                            Console.WriteLine("[{0}] " + customer.Name + "with Address " + customer.Address, i);
                        }
                        bool validselection = false;
                        int num = 0;
                        while(!validselection){
                        try{
                        num = Convert.ToInt32(Console.ReadLine());
                        validselection = true;
                        }
                        catch{
                            Console.WriteLine("Please us whole numbers only");
                            }
                        }
                        finalcustomer = chosen[num];
                        customerselected = false;
                    }
                    if (chosen.Count == 0){
                        Console.WriteLine("No customer with that name was found");
                    }
                    else{
                        finalcustomer = chosen[0];
                        }
                    }
                    MakeOrder PlaceOrder = new MakeOrder(finalcustomer, _customerBL, new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
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