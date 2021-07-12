using StorefrontModels;
using System.Collections.Generic;
using System;
namespace StorefrontDL{
    public interface ILineItemRepository{

        ///returns all customers in repo
        List<LineItem> GetAllLineItems();
        LineItem GetLineItem(LineItem lineitem);
        LineItem AddLineItem(LineItem lineitem);
        LineItem UpdateLineItem(LineItem lineitem);
    }
}