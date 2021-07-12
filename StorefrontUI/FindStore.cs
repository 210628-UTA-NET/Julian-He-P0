/* using System;
using StorefrontModels;
using StorefrontBL;
using System.Collections.Generic;

namespace StorefrontUI{

    public class FindStorePage {
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
        // public Storefront StoreFinder(string option, string param){

        //}
        public Storefront Selection()
        {
            String input = Console.ReadLine();
            switch(input){
                case "1":
                    Console.WriteLine("What is the Name of the Store you wish to find?");
                    string storeName = Console.ReadLine();
                    Storefront store = StoreFinder("1", storeName);
                    return store;
                case "2":
                    Console.WriteLine("What is the Address if the Store you wish to find?");
                    string storeAddress = Console.ReadLine();
                    Storefront store1 = StoreFinder("2", storeAddress);
                    return store1;
                case "3":
                    return null;
                default:
                    return ;
            }
        }
    }
} */