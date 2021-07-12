using StorefrontBL;
using StorefrontModels;
using System.Collections.Generic;
using System;

namespace StorefrontUI{
    
    public class StoreViewOrders : ISelectionPage{
        private IStoreBL _storeBL;

        public StoreViewOrders(IStoreBL p_storeBL){
                _storeBL = p_storeBL;
            }

        public void Page()
        {
            Storefront storetosee;
            List<Storefront> stores = _storeBL.GetAllStore();
            Console.WriteLine("All Available Stores");
            int i = 0;
            foreach(Storefront store in stores){
                Console.WriteLine("["+i+"] " + store.Name + "with address " + store.Address);
                i++;
            }
            Console.WriteLine("Which Store would you like to choose?");
            string choice = Console.ReadLine();
            storetosee = stores[i];
            List<Order> orderlist = storetosee.Orders;
            foreach (Order order in orderlist){
                Console.WriteLine(order.OrderID + "  " + order.TotalPrice);
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