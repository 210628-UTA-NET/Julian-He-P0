using System;
using StorefrontModels;
using StorefrontBL;
using StorefrontDL;
using System.Collections.Generic;
using System.Linq;

namespace StorefrontUI{
    public class MakeOrder : ISelectionPage{
        private ICustomerBL _customerBL;
        private Customer _customer;
        private IStoreBL _storeBL;
        private StorefrontDL.Entities.P0DBContext _context;
        public MakeOrder(Customer p_customer, ICustomerBL p_customerBL, StoreBL p_store, StorefrontDL.Entities.P0DBContext context){
            _storeBL = p_store;
            _customer = p_customer;
            _customerBL = p_customerBL;
            _context = context;


        }

        public void Page()
        {
            Console.WriteLine("Order Placing Menu");
            List<Storefront> Storelist = _storeBL.GetAllStore();
            int i = 0;
            foreach(Storefront store in Storelist){
                Console.WriteLine("[{0}] " + store.Name + " with address "+ store.Address, i+1);
                i++;
            }
            Console.WriteLine("Please enter the number of the store you wish to order from or press 0 to return to the previous page");
        }

        public PageType Selection()
        {
            string selection = Console.ReadLine();
            switch (selection){
                case "0":
                    return PageType.CustomerOptions;
                default:
                    
                    bool ValidStore = false;
                    
                    List<Storefront> stores = _storeBL.GetAllStore();
                    
                    Storefront selected = new Storefront();
                    while(!ValidStore) {
                        try{
                            selected = stores[Convert.ToInt32(selection)-1];
                            ValidStore= true;
                        }
                        catch{
                            Console.WriteLine("Store Number not found, please try again");
                        }
                    }
                    OrderPlacer NewOrder = new OrderPlacer(_storeBL, selected, _customer.ID, _context);
                    OrderBL orderBL = new OrderBL(new OrderRepository(_context));
                    Order order = NewOrder.PlaceOrder();
                    order.CustomerID = _customer.ID;
                    order.Location = selected.ID;
                    return PageType.CustomerOptions;
            }
        }

    }
            
}