using System;
using StorefrontModels;
namespace StorefrontUI{
    public class CustomerMaker : CustomerMakerI
    {
        public void CustomerMaker(){
            Console.WriteLine("This is the Customer Maker");
            Console.WriteLine("Would you like to make a new customer or see all customers?");
            Console.WriteLine("[1] Make a new customer");
            Console.WriteLine("[2] See all customers");

        }
        public void NewCustomer(){
            Customer newCustomer = new Customer();
            Console.WriteLine("What is the Customer's Name?");
            String input = Console.ReadLine();
            newCustomer.Name = input;
            Console.WriteLine("What is the Customer's Address?");
            input = Console.ReadLine();
            newCustomer.Address= input;
            Console.WriteLine("What is the Customer's Contact Info (Email or Phone Number)?");
            input = Console.ReadLine();
            
        }
}
}