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
        public MakeOrder(Customer p_customer, ICustomerBL p_customerBL, StoreBL p_store){
            _storeBL = p_store;
            _customer = p_customer;
            _customerBL = p_customerBL;

        }

        public void Page()
        {
            Console.WriteLine("Order Placing Menu");
        
            Console.WriteLine("Please enter the name of the store you wish to order from or press 0 to return to the previous page");

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
                        string storename = Console.ReadLine();
                        var queryRes = (from store in stores
                                        where store.Name == storename
                                        select store);
            
                    List<Storefront> resList = new List<Storefront>();
                    foreach (var res in queryRes){
                    resList.Add(res);
                    }
                    if (queryRes.Count() > 1){
                        Console.WriteLine("Multiple Stores with this name have been found, which would you like to buy from?");
                
                        for(int i = 0; i<resList.Count();i++){
                            Console.WriteLine("[{0}] " + resList[i].Name + " with address " + resList[i], i);
                            }
                        bool numselect = true;
                        while(numselect){
                        string storenum = Console.ReadLine();                        
                            try{
                                selected = resList[Convert.ToInt32(storenum)];
                                numselect = false;}
                            catch {
                                Console.WriteLine("Index out of bounds please try again");
                                }
                     
                            }
                            ValidStore= true;         
                            }
                        else if (queryRes.Count() == 1){
                        selected = resList[0];
                        ValidStore = true;
                            }
                        else{
                        Console.WriteLine("No Store with that name found, please try again");
                        Console.Clear();
                        Page();
                        }
                    }
                    OrderPlacer NewOrder = new OrderPlacer(_storeBL, selected, _customer.ID);
                    OrderBL orderBL = new OrderBL(new OrderRepository(new StorefrontDL.Entities.P0DBContext()));
                    Order order = NewOrder.PlaceOrder();
                    order.CustomerID = _customer.ID;
                    order.Location = selected.ID;
                    order.OrderID = orderBL.GetAllOrder().Count+1;
                    
                    orderBL.AddOrder(order);
                    return PageType.CustomerOptions;
            }
        }

    }
            
}