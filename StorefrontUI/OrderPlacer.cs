using System;
using StorefrontModels;
using System.Threading;
using System.Collections.Generic;
using StorefrontBL;
using StorefrontDL;
using System.Linq;

namespace StorefrontUI{
    public class OrderPlacer{
        private IStoreBL _storeBL;
        private int _customernumber;
        private Storefront _store;
    public OrderPlacer(IStoreBL p_storeBL, Storefront p_store, int customerID){
        _storeBL = p_storeBL;
        _customernumber = customerID;
        _store = p_store;
    }
    public Order PlaceOrder(){
        Console.WriteLine("This is the Order Placer");
        Order customerorder = new Order(); 
        List<LineItem> orderlist = new List<LineItem>();
        Storefront chosenstore;
        customerorder.CustomerID = _customernumber;
        Console.WriteLine("Please enter the Name of the store where the order will be placed or press 0 to return to go back to the previous page");
        string location = Console.ReadLine();
        if (location == "0"){
            return customerorder;
        }
        List<Storefront> storelist = _storeBL.GetAllStore();
        var queryRes = (from res in storelist
                        where res.Name == location
                        select res);
                
        List<Storefront> reslist = new List<Storefront>();
        foreach (var result in queryRes){
            reslist.Add(result);
            }
        if(reslist.Count == 0){
            Console.WriteLine("No store with this name was found");
            Console.Clear();
            }
        if (reslist.Count > 1){
            Console.WriteLine("Multiple Stores with this name have been found. Which store would you like to order from?");
            for(int i = 0; i<reslist.Count; i++){
                Console.WriteLine("[{0}] " + reslist[i] + "with address " + reslist[i].Address, i);
                }
            int choice = Convert.ToInt32(Console.ReadLine());
            customerorder.Location = reslist[choice].ID;
            chosenstore = reslist[choice];
            Console.Clear();
                }
        else{
            customerorder.Location = reslist[0].ID;
            chosenstore = reslist[0];
            }
        LineItem newItem = new LineItem();
        bool run = true;
        while(run){
            Console.WriteLine("What is the Product you want to add");
            List<Storefront> stores = _storeBL.GetAllStore();
            List<LineItem> targetinventory = chosenstore.Inventory;
            foreach(Storefront store in stores){
                if (store.ID == customerorder.Location){
                    targetinventory = store.Inventory;
                    }
                }
            ProductMaker maker = new ProductMaker();
            Product item = maker.MakeProduct();
            bool ItemInInventory = false;
            LineItem targetlineitem = new LineItem();
            foreach(LineItem items in targetinventory){
                if (items.ProductName.Name == item.Name && items.ProductName.Price == item.Price){
                    ItemInInventory = true;
                    targetlineitem = items;
                }
            }
            if(ItemInInventory == false){
                Console.WriteLine("Item is not in store inventory cannot be added to order");
            }
            else{
                newItem.ProductName = item;
                bool quantityValid = false;
                while(quantityValid)
                Console.WriteLine("How many of this product do you have? Please use numbers only");
                try{
                    newItem.Quantity = Convert.ToInt32(Console.ReadLine());
                    }
                catch{
                    Console.WriteLine("Cannot have decimals or Letters");
                    }
                if (newItem.Quantity > targetlineitem.Quantity){
                    Console.WriteLine("Quantity exceeds avaiable inventory");
                }
                else{};
                customerorder.Items.Add(newItem);
                Console.WriteLine("Would you like to add another item to the order?");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No");
                string cont = Console.ReadLine();
                if (cont == "2"){
                    run=false;
                }
                if (cont == "1"){
                    Console.Clear();
                }
                else{
                    Console.WriteLine("Input invalid, no more products will be added");
                    Console.Clear();
                    run = false;
                    }
                }
            }
        return customerorder;

        }
    }
}
/*while(order){
            Console.WriteLine("What would you like to add first?");
            Console.WriteLine("[1] Order Location:" + customerorder.Location);
            Console.WriteLine("[2] Product List: " + Convert.ToString(customerorder.Items));
            Console.WriteLine("[0] Finish");
            string input = Console.ReadLine();
            
            if (input == "1"){
                
            }
            if (input== "2"){
                
            }
            if (input == "0"){
                order = false;
            }
        }
        return customerorder;
    }
    }
}*/