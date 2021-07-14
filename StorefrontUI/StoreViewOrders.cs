using StorefrontBL;
using StorefrontModels;
using System.Collections.Generic;
using System;
using StorefrontDL;

namespace StorefrontUI{
    
    public class StoreViewOrders : ISelectionPage{
        private IStoreBL _storeBL;
        private StorefrontDL.Entities.P0DBContext _context;

        public StoreViewOrders(IStoreBL p_storeBL, StorefrontDL.Entities.P0DBContext context){
                _storeBL = p_storeBL;
                _context = context;
            }

        public void Page()
        {
            Storefront storetosee;
            List<Storefront> stores = _storeBL.GetAllStore();
            Console.WriteLine("All Available Stores");
            int i = 0;
            foreach(Storefront store in stores){
                Console.WriteLine("["+i+"] " + store.Name + " with address " + store.Address);
                i++;
            }
            Console.WriteLine("Which Store would you like to choose?");
            string choice = Console.ReadLine();
            storetosee = stores[Convert.ToInt32(choice)];
            OrderBL orderBL = new OrderBL(new OrderRepository(_context));
            List<Order> orderlist = orderBL.GetStoreOrder(storetosee.ID);
            foreach (Order order in orderlist){
                Console.WriteLine("Order with order ID " + order.OrderID + "  Total: " + order.TotalPrice);
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