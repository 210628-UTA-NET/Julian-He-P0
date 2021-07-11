using System;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontModels;

namespace StorefrontUI
{
    public class ShowStorefrontPage : ISelectionPage
    {
        private IStoreBL _storeBL;
        public ShowStorefrontPage(IStoreBL p_store)
        {
            _storeBL = p_store;
        }
        public void Page()
        {
            Console.WriteLine("List of Storefronts");

            List<Storefront> stores = _storeBL.GetAllStore();

            foreach (Storefront store in stores)
            {
                Console.WriteLine("=============================");
                Console.WriteLine(store);
                Console.WriteLine("=============================");
            }
            Console.WriteLine("[1] Find a store");
            Console.WriteLine("[0] Go Back");
        }

        public PageType Selection()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return PageType.StorePage;
                case "1":
                    return PageType.FindStorePage;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return PageType.ShowStorefrontPage;
            }
        }
    }
}