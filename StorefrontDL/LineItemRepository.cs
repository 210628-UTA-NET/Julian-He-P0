using System.Collections.Generic;
using Models = StorefrontModels;
using Entity= StorefrontDL.Entities;


namespace StorefrontDL{

    public class LineItemRepository : ILineItemRepository{
        private Entities.P0DBContext _context;
        public LineItemRepository(Entity.P0DBContext p_context){
            _context = p_context;
        }

        public Models.LineItem AddLineItem(Models.LineItem lineitem)
        {
            throw new System.NotImplementedException();
        }

        public List<Models.LineItem> GetAllLineItems()
        {
            throw new System.NotImplementedException();
        }

        public Models.LineItem GetLineItem(Models.LineItem lineitem)
        {
            throw new System.NotImplementedException();
        }

        public Models.LineItem UpdateLineItem(Models.LineItem lineitem)
        {
            throw new System.NotImplementedException();
        }
    }
}