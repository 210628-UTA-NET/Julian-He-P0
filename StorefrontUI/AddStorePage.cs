using System;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontModels;
using StorefrontDL;


namespace StorefrontUI
{
    public class AddStorefrontPage : ISelectionPage
    {
        private static Storefront _storefront = new Storefront();
        private StorefrontDL.Entities.P0DBContext _context;
        private IStoreBL _storeBL;


        public AddStorefrontPage(IStoreBL p_store, StorefrontDL.Entities.P0DBContext context)
        {
            _storeBL = p_store;
            _context = context;
        }
        public void Page()
        {
            Console.WriteLine("Add a Storefront");
                Console.WriteLine("What would you like to add?");
                Console.WriteLine("[5] Store Name: " + _storefront.Name);
                Console.WriteLine("[4] Store Address: " + _storefront.Address);
                Console.WriteLine("[3] Store Inventory");
                Console.WriteLine("[2] Store Orders");
                Console.WriteLine("[1] Add Store");
                Console.WriteLine("[0] Go Back");
            _storefront.ID = _storeBL.GetAllStore().Count+1;

        }

        public PageType Selection()
        {
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "0":
                    return PageType.StorePage;
                case "1":
                    _storeBL.AddStore(_storefront);
                    Console.WriteLine("Store Added");
                    return PageType.AddStorefrontPage;
                case "2":
                    Console.WriteLine("Which customer made this order?");
                    ICustomerBL customerlist = new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext()));
                    List<Customer> AllCustomer = customerlist.GetAllCustomers();
                    Customer chosen; 
                    for(int i = 0; i<AllCustomer.Count; i++){
                        Console.WriteLine("[{0}] :" + AllCustomer[i].Name, i);
                    }
                    string choice = Console.ReadLine();
                    chosen = AllCustomer[Convert.ToInt32(choice)];
                    Console.WriteLine("What are the orders of the store");
                    OrderMaker ordermaker = new OrderMaker(_storefront, chosen.ID);
                    List<Order> ListofOrders = new List<Order>();
                    bool ListComplete = false;
                    OrderBL order = new OrderBL(new OrderRepository(new StorefrontDL.Entities.P0DBContext()));
                    while(!ListComplete){
                        Order newOrder = ordermaker.MakeOrder();
                        order.AddOrder(newOrder);

                        Console.WriteLine("Would you like to add another order?");
                        Console.WriteLine("Yes");
                        Console.WriteLine("No");
                        string response1 = Console.ReadLine();
                        if (response1 == "No"){
                            ListComplete = true;
                        }
                    }
                    return PageType.AddStorefrontPage;
                case "3":
                    ProductMaker productmaker = new ProductMaker(_context);
                    bool inventory = true;
                    HashSet<LineItem> StoreInventory = new HashSet<LineItem>();
                    while (inventory){
                        LineItem storeItem = new LineItem();
                        storeItem.ProductName = productmaker.MakeProduct();
                        Console.WriteLine("How many of this item are in the store?");
                        int quant = Convert.ToInt32(Console.ReadLine());
                        storeItem.Quantity = quant;
                        Console.WriteLine("Would you like to enter another item?");
                        }
                    return PageType.AddStorefrontPage;
                        
                case "4":
                    Console.WriteLine("What is the address of the store");
                    _storefront.Address = Console.ReadLine();
                    return PageType.AddStorefrontPage;
                case "5":
                    Console.WriteLine("What is the name of the Store?");
                    _storefront.Name = Console.ReadLine();
                    return PageType.AddStorefrontPage;
                    

                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return PageType.AddStorefrontPage;
            }
        }
    }
}