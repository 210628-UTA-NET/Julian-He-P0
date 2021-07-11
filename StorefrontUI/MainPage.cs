using System;
namespace StorefrontUI{
    public class MainPage : ISelectionPage
    {
        public void Page()
        {
            Console.WriteLine("Welcome to the Storefront App");
            Console.WriteLine("Which page would you like to go?");
            Console.WriteLine("[1] Customer Page");
            Console.WriteLine("[2] Store Page");
        }

        public PageType Selection()
        {
            string userInput = Console.ReadLine();
            switch(userInput){
                case "1":
                    return PageType.CustomerPage;
                
                case "2":
                    return PageType.StorePage;
                default:
                    Console.WriteLine("Selection not found, please try again");
                    Console.ReadLine();
                    return PageType.MainPage;
            }
        }
    }
}