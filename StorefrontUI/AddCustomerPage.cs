using System;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontModels;
using System.Threading;


namespace StorefrontUI
{
    public class AddCustomerPage : ISelectionPage
    {
        private static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public AddCustomerPage(ICustomerBL p_store)
        {
            _customerBL = p_store;
        }
        public void Page()
        {
            Console.WriteLine("Add a Customer");
                Console.WriteLine("What would you like to do?");

                Console.WriteLine("[5] Add Customer Name: " + _newCustomer.Name);
                Console.WriteLine("[4] Add Customer Address: " + _newCustomer.Address);
                Console.WriteLine("[3] Add Customer Email: "+_newCustomer.EmailPhoneGet("Email"));
                Console.WriteLine("[2] Add Customer Phone: " + _newCustomer.EmailPhoneGet("Phone"));
                Console.WriteLine("[1] Add Customer Orders");
                Console.WriteLine("[0] Go Back");

        }

        public PageType Selection()
        {
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return PageType.CustomerPage;
                case "5":
                    Console.WriteLine("What is the name of the Customer?");
                    _newCustomer.Name = Console.ReadLine();
                    return PageType.AddCustomerPage;
                case "4":
                    Console.WriteLine("What is the address of the Customer?");
                    _newCustomer.Address = Console.ReadLine();
                    return PageType.AddCustomerPage;
                case "3":
                    Console.WriteLine("What is the email of the customer?");
                    string emailValue = Console.ReadLine();
                    _newCustomer.EmailPhoneSet("Email", emailValue);
                    return PageType.AddCustomerPage;
                case "2":
                    Console.WriteLine("What is the phone number of the customer?");
                    string phone = Console.ReadLine();
                    try{
                    _newCustomer.EmailPhoneSet("Phone", phone);
                    }
                    catch{
                        Console.WriteLine("Phone Numbers cannot have Letters");
                    Thread.Sleep(1000);
                    }
                    return PageType.AddCustomerPage;
                case "1":
                    Console.WriteLine("What are the orders of the customer");
                    OrderMaker ordermaker = new OrderMaker();
                    bool continue1 = true;
                    _newCustomer.Orders.Add(ordermaker.MakeOrder());
                    while(continue1){
                        Console.WriteLine("Do you want to add another order?");
                        Console.WriteLine("[1] Yes");
                        Console.WriteLine("[2] No");
                        string res = Console.ReadLine();
                        if (res =="1"){
                            _newCustomer.Orders.Add(ordermaker.MakeOrder());
                        }
                        else if (res == "2"){
                            continue1 = false;
                        }
                        else{
                            Console.WriteLine("Input invalid Please try again");
                            Console.Clear();
                        }
                    }
                    return PageType.AddCustomerPage;
                default: 
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return PageType.AddCustomerPage;
            }
        }
    }
}