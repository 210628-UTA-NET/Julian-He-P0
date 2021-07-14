using System;
using StorefrontModels;
using StorefrontBL;
using System.Collections.Generic;
using StorefrontDL;

namespace StorefrontUI
{

    public class ReplenishInventory : ISelectionPage
    {
        IStoreBL _storeBL;
        private StorefrontDL.Entities.P0DBContext _context;
        public ReplenishInventory(IStoreBL p_store, StorefrontDL.Entities.P0DBContext context)
        {
            _storeBL = p_store;
        }

        public void Page()
        {
            Console.WriteLine("This is the Replenish Page, What would you like to do?");
            Console.WriteLine("[0] Replenish a store inventory");
            Console.WriteLine("[1] Return to the store page");
            
        }

        public bool Replenish(Storefront store)
        {
            bool replenished = false;
            Console.WriteLine(store.Name + "'s inventory list:");
            Console.WriteLine("Product                     Inventory");
            int i = 1;
            LineItemBL lineItemBL = new LineItemBL(new LineItemRepository(new StorefrontDL.Entities.P0DBContext()));
            List<LineItem> items = lineItemBL.GetInventory(store.ID);
            foreach(LineItem item in items){
                Console.WriteLine("[{0}] "+ item.ProductName.Name + "                 " + item.Quantity, i);
                i++;
            }
            Console.WriteLine("Which item would you like to Replenish? or press 0 to return to exit menu");
            string choice = Console.ReadLine();
            if(Convert.ToInt32(choice)-1 > i){
                Console.WriteLine("Item not in inventory");
                return replenished;
            }
            if (Convert.ToInt32(choice) == 0){
                replenished = true;
                return replenished;
            }
            bool validamt = false;
            int finalquant = 0;
            while(!validamt){
                Console.WriteLine("How many would you like to add to this inventory? Please use Whole numbers only");
                int quant =Convert.ToInt32(Console.ReadLine());
                if (quant <0){
                    Console.WriteLine("Cannot add a negative value");
                }else{
                    validamt= true;
                    finalquant = Convert.ToInt32(quant);
                }
            }
            LineItem target = items[Convert.ToInt32(choice)-1];
            //lineItemBL.UpdateLineItem();
        StoreBL storeBL = new StoreBL(new StoreRepository(_context));
        storeBL.Replenish(target, finalquant);
        replenished = true;

        return replenished;
        }

        public PageType Selection()
        {
            string input = Console.ReadLine();
            switch(input){
                case "0":
                    Console.WriteLine("Here is a list of available stores");
                    List<Storefront> stores = _storeBL.GetAllStore();
                    int i = 0;
                    foreach(Storefront store in stores){
                        Console.WriteLine("[{0}] " + store.Name + " with address " + store.Address, i);
                        i++;
                    }
                    Console.WriteLine("Which Store would you like to restock?");
                String targetStore = Console.ReadLine();
                Storefront chosenstore = stores[Convert.ToInt32(targetStore)];
                bool res = false;
                while(!res){
                res = Replenish(chosenstore);
                }
                return PageType.ReplenishInventory;
                case "1":
                    return PageType.StoreOptions;
                default:
                    Console.WriteLine("Input invalid, press enter to continue");
                    Console.ReadLine();
                    return PageType.ReplenishInventory;


            }
        }
    }
} 