using StorefrontBL;
using StorefrontModels;
using System.Collections.Generic;
using System;

namespace StorefrontUI{
    
    public class StoreViewInventory : ISelectionPage{
        private IStoreBL _storeBL;
        private StorefrontDL.Entities.P0DBContext _context;

        public StoreViewInventory(IStoreBL p_storeBL, StorefrontDL.Entities.P0DBContext context){
                _storeBL = p_storeBL;
            }

        public void Page()
        {
            Storefront storetosee;
            List<Storefront> stores = _storeBL.GetAllStore();
            Console.WriteLine("All Available Stores");
            int i = 0;
            foreach(Storefront store in stores){
                Console.WriteLine("["+i+"] " + store.Name + " with address: " + store.Address);
                i++;
            }
            Console.WriteLine("Which Store would you like to choose?");
            string choice = Console.ReadLine();
            storetosee = stores[Convert.ToInt32(choice)];
            Console.WriteLine("\n Here is the Inventory List");
            List<LineItem> Inventorylist = storetosee.Inventory;
            foreach (LineItem lineitem in Inventorylist){
                Console.WriteLine(lineitem.ProductName.Name + "  " + lineitem.Quantity);
            }
            Console.WriteLine("[0] Return to Store Options");
        }

        public PageType Selection(){
            string choice = Console.ReadLine();
            switch(choice){
                case "0":
                    return PageType.StoreOptions;
                default:
                    return PageType.StoreViewOrders;
            }
        }    
    }

}