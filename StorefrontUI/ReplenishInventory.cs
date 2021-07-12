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
            int i = 0;
            foreach(LineItem item in store.Inventory){
                Console.WriteLine("[" +i+"] " + item.ProductName.Name+"                      " + item.Quantity);
                i++;
            }
            Console.WriteLine("Which item would you like to Replenish?");
            string choice = Console.ReadLine();
            bool validamt = false;
            int finalquant = 0;
            while(!validamt){
                Console.WriteLine("How many would you like to add to this inventory? Please use Whole numbers only");
                int quant =Convert.ToInt32(Console.ReadLine());
                if (quant <0){
                    Console.WriteLine("Cannot add a negative value");
                }else{
                    validamt= true;
                    finalquant = quant;
                }
            }
            foreach(LineItem item in store.Inventory){
                if (item.ProductName.Name == choice){
                    item.Quantity += finalquant;
                }
            }
            
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

                List<Storefront> ReplenishingStores = new List<Storefront>();
                foreach(Storefront store in stores){
                    if (store.Name == targetStore){
                        ReplenishingStores.Add(store);
                    }
                }
                Storefront chosenstore = new Storefront();
                bool validation = true;
                while(validation){
                    if(ReplenishingStores.Count > 1){
                    Console.WriteLine("Multiple Stores with this name, can only restock one at a time");
                    Console.WriteLine("Which store would you like to chose");
                    for(int i = 0; i< ReplenishingStores.Count;i++){
                        Console.WriteLine("[{0}] " + ReplenishingStores[i].Name + "with address "+ ReplenishingStores[i].Address);
                    }
                    string choice = Console.ReadLine();
                    if (Convert.ToInt32(choice) > (ReplenishingStores.Count-1)){
                        Console.WriteLine("Input invalid");
                    }
                    else if (ReplenishingStores.Count== 0){
                        Console.WriteLine("No store with that name found");
                        }
                    }
                    else{
                        chosenstore = ReplenishingStores[0];
                        validation= false;
                    }
                }
                Replenish(chosenstore);
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