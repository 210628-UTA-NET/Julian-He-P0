using System;
using StorefrontDL;
using System.Collections.Generic;
using StorefrontModels;
using StorefrontBL;

namespace StorefrontUI{
    
    public class CustomerPage : ISelectionPage{

        public PageType Selection()
                   {
            Console.WriteLine("What would you like to do??");
            Console.WriteLine(" [1] Make a new customer");
            Console.WriteLine(" [2] See all customers");
            Console.WriteLine(" [3] Exit");
            String UserInput = Console.ReadLine();

            switch(UserInput){
                case "1":
                    Customer customer = new Customer();
                    Console.WriteLine("Customer Name?");
                    customer.Name= Console.ReadLine();
                    Console.WriteLine("Customer Address?");
                    customer.Address= Console.ReadLine();
                    Console.WriteLine("Customer Email or Phone Number?");
                    customer.EmailPhone = Console.ReadLine();
                    bool input = true;
                    Console.WriteLine("Do you want to create the customer's order list?");
                    Console.WriteLine("Yes");
                    Console.WriteLine("No");
                    string decision = Console.ReadLine();
                    if (decision == "Yes"){
                        List<Order> orderList = new List<Order>();
                        while(input){
                            Console.WriteLine("What is the Location of the order");
                            string input2 = Console.ReadLine();
                            Order neworder = new Order();
                            neworder.Location = input2;
                            Console.WriteLine("What is the total price of the order?");
                            string total = Console.ReadLine();
                        }
                    }
                    else{

                        }

                    
                    

                case "2":
                    return ;
                
                case "3":
                    return PageType.MainPage;
                   }
                }

        public void Page()
        {
            Console.WriteLine("Welcome to the Customer Page");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Find a Customer");
            Console.WriteLine("[2] Add a Customer");
            Console.WriteLine("[3] Return to the main menu");
        }
    }
}