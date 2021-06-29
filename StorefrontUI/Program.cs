using System;
using StorefrontModels;

namespace StorefrontUI
{
    class Program
    {   
        static void Main(string[] args)
        {
            List<Customer> CustomerList = new List<Customer>();
            Bool repeat = true;
            while (repeat){
                Console.Clear;
                Console.WriteLine("Welcome to the Store, what would you like to do?");
                Console.WriteLine("[1] Go to Customer Menu");
                string userInput = Console.ReadLine();
                switch(userInput){
                    case "1": return "CustomerMenu";
                }
            }
        }
    }


}