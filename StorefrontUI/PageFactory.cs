using StorefrontBL;
using StorefrontDL;
using System;


namespace StorefrontUI
{
    public class PageFactory : IPageFactory
    {
        private StorefrontDL.Entities.P0DBContext context = new StorefrontDL.Entities.P0DBContext();
        public ISelectionPage GetMenu(PageType p_page)
        {
            StoreBL storeBL = new StoreBL(new StoreRepository(context));
            CustomerBL customerBL = new CustomerBL(new CustomerRepository(context));
            switch (p_page)
            {
                case PageType.MainPage:
                    return new MainPage();
                case PageType.StorePage:
                    return new StorePage();
                case PageType.ShowStorefrontPage:
                    return new ShowStorefrontPage(storeBL, context);
                case PageType.AddStorefrontPage:
                    return new AddStorefrontPage(storeBL, context);
               // case PageType.FindStorePage:
                    //return new FindStorePage(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
                //case PageType.FindCustomerPage:
                    // new FindCustomerPage(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.CustomerPage:
                    return new CustomerPage();
                case PageType.ShowCustomerPage:
                    return new ShowCustomerPage(customerBL, context);
                case PageType.AddCustomerPage:
                    return new AddCustomerPage(context);
                case PageType.ReplenishInventory:
                    return new ReplenishInventory(storeBL, context);
                case PageType.StoreOptions:
                    return new StoreOptions(storeBL, context);
                case PageType.CustomerOptions:
                    return new CustomerOptions(customerBL, context);
                case PageType.StoreViewOrders:
                    return new StoreViewOrders(storeBL, context);
                case PageType.CustomerViewOrders:
                    return new CustomerViewOrders(customerBL, context);
                case PageType.ViewInventory:
                    return new StoreViewInventory(storeBL, context);
                default:
                    return null;
            }
        }
    }
}