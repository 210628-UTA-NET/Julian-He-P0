using StorefrontModels;
using System;
using StorefrontDL;
using StorefrontBL;

namespace StorefrontUI{

    public class StoreOptions : ISelectionPage{
        
        private StoreBL _store; 
        public StoreOptions(StoreBL p_store){
            _store = p_store;
        }

        public void Page()
        {
            Console.WriteLine("Welcome to Store options, what would you like to do?");
            Console.WriteLine("[1] View Orders");
            Console.WriteLine("[2] Replenish Inventory");
            Console.WriteLine("[3] View Inventory");
            Console.WriteLine("[4] return to store menu");
        }

        public PageType Selection()
        {
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    return PageType.StoreViewOrders;
                case "2": 
                    /* ReplenishInventory rep = new ReplenishInventory(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext()) ));
                    Console.Clear();
                    rep.Page();
                    PageType page = rep.Selection(); */
                    return PageType.ReplenishInventory;
                case "3":
                    return PageType.ViewInventory;
                case "4":
                    return PageType.StorePage;
                default:
                    Console.WriteLine("Input invalid, press enter to continue");
                    Console.ReadLine();
                    return PageType.StoreOptions;
            }
        }
    }
}