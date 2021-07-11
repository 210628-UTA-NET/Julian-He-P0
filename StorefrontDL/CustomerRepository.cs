using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StorefrontModels;
namespace StorefrontDL{
    public class CustomerRepository : ICustomerRepository{
        private const string _filePath = "./../StorefrontDL/Database/Customer.json";
        private string _jsonString;

        public Customer AddCustomer(Customer customer)
        {
            List<Customer> customerList = this.GetAllCustomers();
            customerList.Add(customer);
            String jsonserialized = JsonSerializer.Serialize(customerList, new JsonSerializerOptions{WriteIndented=true});
            string filename = "Customer.json";
            File.WriteAllText(filename, jsonserialized);
            return customer;
        }

        public List<Customer> GetAllCustomers()
                {
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            //This will return a list of restaurant from the jsonString that came from 
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public Customer GetCustomer(Customer customer)
        {
            string customername = customer.Name;
            string customeraddress = customer.Address;
            List<Customer> customerlist = this.GetAllCustomers();
            Customer found = null;
            foreach (Customer customerentry in customerlist){
                if(customername == customerentry.Name && customeraddress == customerentry.Address){
                    found= customer;
                    break;
                }
            }
            return found;
        }
    }
}