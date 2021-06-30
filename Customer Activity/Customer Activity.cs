using System;
using StorefrontModels;
using System.Collections;
using System.Collections.Generic;
namespace Customer_Activity
{
    class Program
    {
        List<T> customerList = new List<T>();
        static void Main(string[] args)
        {
            Console.WriteLine("would you like to make a customer or see all customers?");
            Console.WriteLine(" [1] Make a new customer");
            Console.WriteLine(" [2] See all customers");
            String UserInput = Console.ReadLine();

            switch(UserInput){
                case "1":
                    Customer customer = new Customer();
                    Console.WriteLine("Customer Name?");
                    customer.Name= Console.ReadLine();
                    Console.WriteLine("Customer Address?");
                    customer.Address= Console.ReadLine();
                    Console.WriteLine("Customer Email or Phone Number?");
                    customer.EmailPhone = Console.ReadLine();
                    bool input = true;
                    Console.WriteLine("What are the customer's orders? Enter them now or type 'no' to finish");
                    List<T> orderList = new List<T>();
                    while(input){
                        string input2 = Console.ReadLine();
                        if (input2 == "no"){
                            customer.Orders= orderList;
                        }
                        else{
                            orderList.Add(input2);
                        }

                    }
                case "2":
                    for(int i = 0; i <= customerList.Count;i++ ){
                        Console.WriteLine(customerList[i]);
                    }
            }
        }
    }
}
