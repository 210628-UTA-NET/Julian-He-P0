using System;
using StorefrontDL;
using System.Collections.Generic;
using StorefrontModels;
using StorefrontBL;

namespace StorefrontUI{
    
    public class CustomerPage : ISelectionPage{
        ICustomerBL _customerBL;
        public CustomerPage(ICustomerBL p_customer){
            _customerBL = p_customer;
        }

        public PageType Selection()
                   {
            string userInput = Console.ReadLine();
                switch(userInput){
                    case "1": return PageType.ShowCustomerPage;
                    case "2": return PageType.AddCustomerPage;

                    case "3": 
                        return PageType.MainPage;
                    default:
                        Console.WriteLine("Option not found, please press enter to try agian");
                        Console.ReadLine();
                        return PageType.StorePage;
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