using StorefrontModels;
using System;
namespace StorefrontUI{

    public class StoreOptions : ISelectionPage{
        
        private Storefront _targetStore; 
        public StoreOptions(Storefront store){
            _targetStore = store;
        }

        public void Page()
        {
            Console.WriteLine("Welcome to " +_targetStore.Name+ "'s Store, what would you like to do?");
            Console.WriteLine("[1] View Orders");
            Console.WriteLine("[2] Replenish Inventory");
            Console.WriteLine("[3] View Inventory");
            Console.WriteLine("[4] Find a different store");
        }

        public PageType Selection()
        {
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    return PageType.StoreViewOrders;
                case "2": 
                    return PageType.ReplenishInventory;
                case "3":
                    return PageType.ViewInventory;
                case "4":
                    return PageType.FindStorePage;
                default:
                    Console.WriteLine("Input invalid, press enter to continue");
                    Console.ReadLine();
                    return PageType.ReplenishInventory;
            }
        }
    }
}