
using System;
using System.Collections.Generic;
using System.IO;
using Models = StorefrontModels;
using Entity = StorefrontDL.Entities;
using System.Linq;

namespace StorefrontDL
{
    public class StoreRepository : IStoreRepository
    {
        private Entities.P0DBContext _context;
        public StoreRepository(Entity.P0DBContext p_context){
            _context = p_context;
        }

        public Models.Storefront AddStore(Models.Storefront store)
        {
            _context.Storefronts.Add(new Entity.Storefront{
                Name = store.Name,
                Address = store.Address,
                
            });
            _context.SaveChanges();
            return store; 
        }

        public List<Models.Storefront> GetAllStores()
        {
          return _context.Storefronts.Select(store => new Models.Storefront(){
                                                ID = store.Id, 
                                                Name = store.Name,
                                                Address = store.Address

          }).ToList();
        }

        public Models.Storefront GetStorefront(Models.Storefront store)
        {
            throw new NotImplementedException();
        }
    }
}