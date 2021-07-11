using System;
using StorefrontModels;
using StorefrontBL;
using StorefrontDL;
using System.Collections.Generic;

namespace StorefrontUI{
    public class MakeOrder : ISelectionPage{
        private ICustomerBL _customerBL;
        private static Order _order;
        private Customer _customer;
        public MakeOrder(Customer p_customer, ICustomerBL p_customerBL){

        }

        public void Page()
        {
            Console.WriteLine("Order Placing Menu");
            Console.WriteLine("Please enter the name of the store you wish to order from");
            string storename = Console.ReadLine();
            List<Storefront> stores = new StoreBL(new StoreRepository()).GetAllStore();
        }

        public PageType Selection()
        {
            throw new NotImplementedException();
        }
    }
}