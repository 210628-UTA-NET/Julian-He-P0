using System;
using StorefrontModels;
using StorefrontBL;
using System.Collections.Generic;

namespace StorefrontUI{

    public class FindStorePage : ISelectionPage{
        private IStoreBL _storeBL;
        public FindStorePage(IStoreBL p_store){
            _storeBL = p_store;
        }
        public void Page()
        {
            Console.WriteLine("How would you like to find the Store?");
            Console.WriteLine("[1] Store Name");
            Console.WriteLine("[2] Store Address");
            Console.WriteLine("[3] Return to Menu");


        }

        public PageType Selection()
        {
            String input = Console.ReadLine();
            switch(input){
                case "1":
                    Console.WriteLine("What is the Name of the Store you wish to find?");
                    string storeName = Console.ReadLine();
                    List<Storefront> stores  = _storeBL.GetAllStore();
                    foreach (Storefront store in stores){
                        if (store.Name == storeName){
                            StoreOptions storechoice = new StoreOptions(store);
                            
                        }
                        
                    }
                    return PageType.MainPage;
                default:
                    return PageType.FindStorePage;
            }
        }
    }
}