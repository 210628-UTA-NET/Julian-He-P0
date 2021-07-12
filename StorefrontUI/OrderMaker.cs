using System;
using StorefrontModels;
using System.Threading;
using System.Collections.Generic;
using StorefrontBL;
using System.Linq;

namespace StorefrontUI{
    public class OrderMaker{
        private IStoreBL _storeBL;
        private int _customernumber;
        Storefront _store;
    public OrderMaker(IStoreBL p_storeBL, int customerID){
        _storeBL = p_storeBL;
        _customernumber = customerID;
    }
    public OrderMaker(Storefront p_store, int customerID){
        _store = p_store;
        _customernumber = customerID;
    }
    public Order MakeOrder(){
        Console.WriteLine("This is the Order Maker");
        Order customerorder = new Order(); 
        List<LineItem> orderlist = new List<LineItem>();
        Storefront chosenstore;
        customerorder.TotalPrice = 0;
        customerorder.CustomerID = _customernumber;
        Console.WriteLine("Please enter the Name of the store where the order was placed");
                string location = Console.ReadLine();
                List<Storefront> storelist = _storeBL.GetAllStore();
                var queryRes = (from res in storelist
                                    where res.Name == location
                                    select res);
                List<Storefront> reslist = new List<Storefront>();
                foreach (var result in queryRes){
                    reslist.Add(result);
                }
                if (reslist.Count > 1){
                    Console.WriteLine("Multiple Stores with this name have been found. Which store would you like to order from?");
                    for(int i = 0; i<reslist.Count; i++){
                        Console.WriteLine("[{0}] " + reslist[i] + "with address " + reslist[i].Address, i);
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    customerorder.Location = reslist[choice].ID;
                    chosenstore = reslist[choice];
                }
                else{
                    chosenstore = reslist[0];
                    customerorder.Location = reslist[0].ID;
                }
        Console.Clear();
        Console.WriteLine("Now adding items to order");
        LineItem newItem = new LineItem();
                bool run = true;
                while(run){
                Console.WriteLine(chosenstore.Name + "'s Inventory:");
                foreach(LineItem invItem in chosenstore.Inventory){
                    Console.WriteLine(invItem.ToString());
                }
                Console.WriteLine("What is the Product you want to add");

                ProductMaker maker = new ProductMaker();
                Product item = maker.MakeProduct();
                newItem.ProductName = item;
                Console.WriteLine("How many of this product do you have?");
                try{
                newItem.Quantity = Convert.ToInt32(Console.ReadLine());
                    }
                catch{
                    Console.WriteLine("Cannot have decimals or Letters");
                }
                customerorder.Items.Add(newItem);
                customerorder.TotalPrice += newItem.ProductName.Price*newItem.Quantity;
                bool ProdInInventory = false;
                foreach (LineItem invenItem in chosenstore.Inventory ){
                    if ((item.Name == invenItem.ProductName.Name) && (item.Price == invenItem.ProductName.Price)){
                        ProdInInventory = true;
                    }
                }
                if(ProdInInventory == false){
                    LineItem ProdToAdd = new LineItem();
                    ProdToAdd.StoreID = customerorder.Location;
                    ProdToAdd.ProductName = item;
                    ProdToAdd.Quantity = 0;
                    chosenstore.Inventory.Add(ProdToAdd);
                }
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
            return customerorder;
        }
    }
}
        /*(order){
            Console.WriteLine("What would you like to add first?");
            Console.WriteLine("[1] Order Location:" + customerorder.Location);
            Console.WriteLine("[2] Product List: " + Convert.ToString(customerorder.Items));
            Console.WriteLine("[0] Finish");
            string input = Console.ReadLine();
            if (input == "1"){
                Console.WriteLine("Please enter the Name of the store where the order was placed");
                string location = Console.ReadLine();
                List<Storefront> storelist = _storeBL.GetAllStore();
                var queryRes = (from res in storelist
                                    where res.Name == location
                                    select res);
                List<Storefront> reslist = new List<Storefront>();
                foreach (var result in queryRes){
                    reslist.Add(result);
                }
                if (reslist.Count > 1){
                    Console.WriteLine("Multiple Stores with this name have been found. Which store would you like to order from?");
                    for(int i = 0; i<reslist.Count; i++){
                        Console.WriteLine("[{0}] " + reslist[i] + "with address " + reslist[i].Address, i);
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    customerorder.Location = reslist[choice].ID;
                    chosenstore = reslist[choice];
                }
                else{
                    chosenstore = reslist[0];
                    customerorder.Location = reslist[0].ID;
                }
            }
            if (input== "2"){
                LineItem newItem = new LineItem();
                bool run = true;
                while(run){
                Console.WriteLine(chosenstore.Name + "'s Inventory:");
                foreach(LineItem invItem in chosenstore.Inventory){
                    Console.WriteLine(invItem.ToString());
                }
                Console.WriteLine("What is the Product you want to add");

                ProductMaker maker = new ProductMaker();
                Product item = maker.MakeProduct();
                foreach (LineItem invenItem in chosenstore.Address )
                newItem.ProductName = item;
                Console.WriteLine("How many of this product do you have?");
                try{
                newItem.Quantity = Convert.ToInt32(Console.ReadLine());
                    }
                catch{
                    Console.WriteLine("Cannot have decimals or Letters");
                }
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
            if (input == "0"){
                order = false;
            }
        }
        return customerorder;
    }
    }
}*/