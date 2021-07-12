/* using System;
using StorefrontModels;
using StorefrontBL;
using System.Collections.Generic;
using System.Linq;

namespace StorefrontUI{

    public class FindCustomerPage : ISelectionPage{
        private ICustomerBL _customerBL;
        public FindCustomerPage(ICustomerBL p_customer){
            _customerBL = p_customer;
        }
        public void Page()
        {
            Console.WriteLine("How would you like to find the Customer?");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Address");
            Console.WriteLine("[3] Email");
            Console.WriteLine("[4] Phone");
            Console.WriteLine("[5] Return to Menu");

        }

        public PageType Selection()
        {
            String input = Console.ReadLine();
            switch(input){
                case "1":
                    bool customernotfound= true;
                    List<Customer> result = new List<Customer>();
                    while(customernotfound){
                    Console.WriteLine("What is the Name of the Customer you wish to find?");
                    string customerName = Console.ReadLine();
                    List<Customer> customers  = _customerBL.GetAllCustomers();
                    var queryResult = (from customer in customers
                                            where customer.Name == customerName
                                            select customer);
                    foreach (var res in queryResult){
                        result.Add(res);
                    }
                    if (queryResult == null){
                        Console.WriteLine("Cannot find specified customer");
                        Console.WriteLine("Would you like to use a different name or try another method?");
                        Console.WriteLine("[1] Try another name");
                        Console.WriteLine("[2] Use another method");
                        string UserInput = Console.ReadLine();
                        if (UserInput == "1"){

                        } 
                        if (UserInput == "2"){
                            return PageType.FindCustomerPage ;
                        }
                    }
                    customernotfound = false;
                    }
                    Customer result1;   
                    if (result.Count > 1){
                        Console.WriteLine("Multiple People with this name found, please select the one you wish to choose. ");
                         
                        for(int i= 0; i<result.Count; i++){
                        Console.WriteLine("{0}"+ result[i].Name + " with Address: " + result[i].Address, i);
                        }
                        result1 = result[Convert.ToInt32(Console.ReadLine())];
                        
                    }
                    else{
                        result1 = result[0];
                    }
                    CustomerOptions choice = new CustomerOptions( result1, _customerBL);
                        Console.Clear();
                        choice.Page();
                        PageType page = choice.Selection();
                        return page;
                    
                case "2":

                    return PageType.FindCustomerPage;
                case "3":
                    return PageType.FindCustomerPage;
                case "4":
                    return PageType.FindCustomerPage;
                case "5":
                    return PageType.CustomerPage;
                default:
                    return PageType.FindCustomerPage;
            }
        }
    }
} */