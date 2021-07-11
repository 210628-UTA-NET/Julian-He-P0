using System;
using StorefrontModels;
using StorefrontBL;
using System.Collections.Generic;

namespace StorefrontUI
{

    public class ReplenishInventory : ISelectionPage
    {
        IStoreBL _storeBL;
        public ReplenishInventory(IStoreBL p_store)
        {
            _storeBL = p_store;
        }

        public void Page()
        {
            Console.WriteLine("This is the Replenish Page, What would you like to do?");
            Console.WriteLine("[0] Replenish a store inventory");
            Console.WriteLine("[1] Return to the store page");
            
        }

        public void Replenish(Storefront store)
        {
            Console.WriteLine(store.Name + "'s inventory list:");
            Console.WriteLine("Product                     Inventory");
            List<LineItem> itemslist = new List<LineItem>();
            foreach(LineItem item in store.Inventory){
                Console.WriteLine(item.ProductName.Name+"                      " + item.Quantity+ "\n");
            }
            Console.WriteLine("Which item would you like to Replenish?");
            

        }

        public PageType Selection()
        {
            string input = Console.ReadLine();
            switch(input){
                case "0":
                    Console.WriteLine("Here is a list of available stores");
                    List<Storefront> stores = _storeBL.GetAllStore();
                    foreach(Storefront store in stores){
                        Console.WriteLine(store.Name);
                    }
                    Console.WriteLine("Which Store would you like to restock?");
                String targetStore = Console.ReadLine();
            
                foreach(Storefront store in stores){
                    if (store.Name == targetStore){
                        Replenish(store);
                        break;
                    }
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