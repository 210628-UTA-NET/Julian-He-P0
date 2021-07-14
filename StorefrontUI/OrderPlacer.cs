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
        private StorefrontDL.Entities.P0DBContext _context;
    public OrderPlacer(IStoreBL p_storeBL, Storefront p_store, int customerID, StorefrontDL.Entities.P0DBContext context){
        _storeBL = p_storeBL;
        _customernumber = customerID;
        _store = p_store;
        _context = context;
    }
    public Order PlaceOrder(){
        Console.WriteLine("This is the Order Placer");
        Order customerorder = new Order(); 
        List<LineItem> orderlist = new List<LineItem>();
        LineItem newItem = new LineItem();
        bool run = true;
        OrderBL orderBL = new OrderBL(new OrderRepository(_context));
        Console.WriteLine("gotten orders");
        newItem.OrderID =orderBL.GetAllOrder().Count+1;
        newItem.StoreID = _store.ID;
        while(run){
            Console.WriteLine("Inventory of " + _store.Name);
            List<LineItem> targetinventory = _store.Inventory;
            int i = 0;
            foreach(LineItem item in targetinventory){
                Console.WriteLine("[{0}] " +item.ProductName.Name + " has quanitity "+ item.Quantity, i);
            }
            Console.WriteLine("What is the Product number you want to add to the Order");
            bool ItemInInventory = false;
            LineItem targetlineitem = new LineItem();
            while(!ItemInInventory){
            string num = Console.ReadLine();
            int itemnum = Convert.ToInt32(num);
            try{
            targetlineitem = targetinventory[itemnum];
            ItemInInventory = true;
            }
            catch{
                Console.WriteLine("Item number not found");
            }}
            newItem.ProductName = targetlineitem.ProductName;
            bool quantityValid = false;
            while(!quantityValid){
                Console.WriteLine("How many of this product do you have? Please use whole numbers only");
                string num2 = Console.ReadLine();
                try{
                    
                    newItem.Quantity = Convert.ToInt32(num2);
                    }
                catch{
                    Console.WriteLine("Cannot have Letters in amount");
                    }
                if (newItem.Quantity > targetlineitem.Quantity){
                    Console.WriteLine("Quantity exceeds avaiable inventory");
                }
                else{
                    targetlineitem.Quantity -= newItem.Quantity;
                    quantityValid = true;
                };}
                
                customerorder.Items.Add(newItem);
                customerorder.TotalPrice += newItem.Quantity+newItem.ProductName.Price;
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
        customerorder.CustomerID = _customernumber;
        customerorder.Location = _store.ID;
        orderBL.PlaceOrder(customerorder);
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