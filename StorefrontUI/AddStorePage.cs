using System;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontModels;


namespace StorefrontUI
{
    public class AddStorefrontPage : ISelectionPage
    {
        private IStoreBL _storeBL;
        public AddStorefrontPage(IStoreBL p_store)
        {
            _storeBL = p_store;
        }
        public void Page()
        {
            Console.WriteLine("Add a Storefront");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Add a Store to the Storefront list");
                Console.WriteLine("[2] Go Back");

        }

        public PageType Selection()
        {
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "2":
                    return PageType.StorePage;
                case "1":

                    Storefront newStore = new Storefront();
                    ProductMaker productmaker = new ProductMaker();
                    Console.WriteLine("Please enter the information about the store");
                    
                Console.WriteLine("What is the name of the Store?");
                newStore.Name = Console.ReadLine();
                Console.WriteLine("What is the address of the store?");
                newStore.Address =  Console.ReadLine();
                Console.WriteLine("What is the inventory of the store?");
                bool inventory = true;
                HashSet<LineItem> StoreInventory = new HashSet<LineItem>();
                while (inventory){
                    LineItem storeItem = new LineItem();
                    
                    storeItem.ProductName = productmaker.MakeProduct();
                    Console.WriteLine("How many of this item are in the store?");
                    int quant = Convert.ToInt32(Console.ReadLine());
                    storeItem.Quantity = quant;
                    Console.WriteLine("Would you like to enter another item?");
                    

                }
                Console.WriteLine("Would you like to enter the orders of this store?");
                Console.WriteLine("Yes");
                Console.WriteLine("No");
                string response = Console.ReadLine();
                if (response == "Yes"){
                    Console.WriteLine("What are the orders of the store");
                    OrderMaker ordermaker = new OrderMaker();
                    List<Order> ListofOrders = new List<Order>();
                    bool ListComplete = false;
                    while(!ListComplete){
                        Order newOrder = ordermaker.MakeOrder();
                        ListofOrders.Add(newOrder);
                        Console.WriteLine("Would you like to add another order?");
                        Console.WriteLine("Yes");
                        Console.WriteLine("No");
                        string response1 = Console.ReadLine();
                        if (response1 == "No"){
                            ListComplete = true;
                        }
                    }
                }
                _storeBL.AddStore(newStore);
                return PageType.AddStorefrontPage;
                    

                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return PageType.AddStorefrontPage;
            }
        }
    }
}