using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models = StorefrontModels;
using Entity = StorefrontDL.Entities;
using System.Linq;

namespace StorefrontDL{
    public class CustomerRepository : ICustomerRepository{
        private Entity.P0DBContext _context;
        public CustomerRepository(Entity.P0DBContext p_context){
            _context= p_context;
        }
        public Models.Customer AddCustomer(Models.Customer customer)
        {
            _context.Customers.Add(new Entity.Customer{
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.EmailPhoneGet("Phone"),
                Email = customer.EmailPhoneGet("Email"),
            });
            _context.SaveChanges();
            return customer;
        }

        public List<Models.Customer> GetAllCustomers()
            {
                return _context.Customers.Select(custom => 
                new Models.Customer(){
                    ID= custom.Id,
                    Name = custom.Name,
                    Address = custom.Address,
                    Email = custom.Email,
                    Phone = custom.Phone
                }).ToList();
        }

        public Models.Customer GetCustomer(Models.Customer customer)
        {
            throw new NotImplementedException();
            
        }
    }
}