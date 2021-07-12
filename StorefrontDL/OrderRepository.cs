using System.Collections.Generic;
using Models = StorefrontModels;
using System.Linq;
using Entity = StorefrontDL.Entities;

namespace StorefrontDL{
    public class OrderRepository : IOrderRepository
    {
        private Entities.P0DBContext _context;
        public OrderRepository(Entities.P0DBContext p_context){
            _context = p_context;
        }
        public Models.Order AddOrder(Models.Order order)
        {
            throw new System.NotImplementedException();
        }

        public List<Models.Order> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public Models.Order GetOrder(Models.Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}