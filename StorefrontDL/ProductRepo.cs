using Models = StorefrontModels;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text.Json;
using Entity = StorefrontDL.Entities;
namespace StorefrontDL{
    public class ProductRepository : IProductRepository
        {
        private Entities.P0DBContext _context;
        private string _jsonString;
        public ProductRepository(Entity.P0DBContext p_context){
            _context = p_context;
        }
        public Models.Product AddProduct(Models.Product product)
        {
            _context.Products.Add(new Entity.Product{
                Name = product.Name,
                Price = product.Price
            });
            return product;

        }

        public List<Models.Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Models.Product GetProduct(Models.Product product)
        {
            string ProductName = product.Name;
            double ProductPrice = product.Price;
            List<Models.Product> productlist = this.GetAllProducts();
            Models.Product found = null;
            foreach (Models.Product product1 in productlist){
                if(ProductName == product1.Name && ProductPrice == product1.Price){
                    found= product1;
                    break;
                }
            }
            return found;
        }
    }
}