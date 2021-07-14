using System;
using StorefrontBL;
using StorefrontModels;
using System.Collections.Generic;

namespace StorefrontUI{
    public class ShowCustomerPage : ISelectionPage
    {
        private StorefrontDL.Entities.P0DBContext _context;
        private ICustomerBL _customerBL;
        public ShowCustomerPage(ICustomerBL p_customer, StorefrontDL.Entities.P0DBContext context){
        _customerBL = p_customer;
        _context = context;
    }
        public void Page()
        {
            Console.WriteLine("List of Customers");
            List<Customer> customers = _customerBL.GetAllCustomers();
            foreach (Customer customer in customers){
                Console.WriteLine("============================");
                Console.WriteLine(customer.Name);
                Console.WriteLine("============================");
            }
            Console.WriteLine("[0] Find a Customer");
            Console.WriteLine("[1] Go Back");
        }

        public PageType Selection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return PageType.FindCustomerPage;
                case "1":
                    return PageType.CustomerPage;
                default:
                Console.WriteLine("Input Not Recognized");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                    return PageType.ShowCustomerPage;
            }
        }

    }
    
}