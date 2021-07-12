using System;
using StorefrontModels;
using System.Threading;

namespace StorefrontUI{

    public class ProductMaker{

    
    public ProductMaker(){
        
        }
    public Product MakeProduct(){
            Product storeProduct = new Product();
            bool run = true;
            while(run){
                Console.WriteLine("What would you like to add first to the product");
                Console.WriteLine("[1] Product Name:" + storeProduct.Name);
                Console.WriteLine("[2] Price: " + Convert.ToString(storeProduct.Price));
                Console.WriteLine("[3] Description: " + storeProduct.Desc);
                Console.WriteLine("[4] Category: " + storeProduct.Category);
                
                string input = Console.ReadLine();
                if(input == "1"){
                    try{
                        storeProduct.Name = Console.ReadLine();
                        }
                    catch{
                        Console.WriteLine("Product Names cannot have numbers");
                        Thread.Sleep(1000);
                        }
                    }
                if(input =="2"){
                    try{
                        storeProduct.Price = Convert.ToDouble(Console.ReadLine());
                        }
                    catch{
                        Console.WriteLine("Price cannot have letters or be negative");
                        }
                    }
                if (input == "3"){
                    storeProduct.Desc = Console.ReadLine();
                    }      
                if (input == "4"){
                    storeProduct.Category = Console.ReadLine();
                    }
                if (input == "0"){
                    if (storeProduct.Name == null){
                        Console.WriteLine("Name cannot be empty");
                        }
                    if (storeProduct.Price == 0){
                        Console.WriteLine("Price cannot be empty");
                        }
                    else{
                        run =false;
                        }
                    }
                }
            return storeProduct;
        }
    }
}