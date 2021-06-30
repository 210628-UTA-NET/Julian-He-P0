using System;

namespace StorefrontUI{
    
    public class StorePage : ISelectionPage{

        public PageType Selection()
            {
                string userInput = Console.ReadLine();
                switch(userInput){
                    case "4": 
                        return PageType.MainPage;
                    default:
                        Console.WriteLine("Option not found, please press enter to try agian");
                        Console.ReadLine();
                        return PageType.StorePage;
                }
            }

        public void Page()
        {
            Console.WriteLine("Welcome to the Store Page");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Find a Store");
            Console.WriteLine("[2] Add a Store");
            Console.WriteLine("[3] Place an Order");
            Console.WriteLine("[4] Return to the main menu");
        }
    }
}