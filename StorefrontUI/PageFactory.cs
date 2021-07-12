using StorefrontBL;
using StorefrontDL;
using System;


namespace StorefrontUI
{
    public class PageFactory : IPageFactory
    {
        public ISelectionPage GetMenu(PageType p_page)
        {
            switch (p_page)
            {
                case PageType.MainPage:
                    return new MainPage();
                case PageType.StorePage:
                    return new StorePage();
                case PageType.ShowStorefrontPage:
                    //ShowRestaurantMenu needs a RestaurantBL object in the parameter because it depends on that object to be able to run its functionality
                    //RestaurantBL needs the Repository object in the parameter because it depends on that object to be able to run
                    //This is call Dependency Injection
                    return new ShowStorefrontPage(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.AddStorefrontPage:
                    return new AddStorefrontPage(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
               // case PageType.FindStorePage:
                    //return new FindStorePage(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
                //case PageType.FindCustomerPage:
                    // new FindCustomerPage(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.CustomerPage:
                    return new CustomerPage(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.ShowCustomerPage:
                    return new ShowCustomerPage(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.AddCustomerPage:
                    return new AddCustomerPage(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.ReplenishInventory:
                    return new ReplenishInventory(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.StoreOptions:
                    return new StoreOptions(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.CustomerOptions:
                    return new CustomerOptions(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.StoreViewOrders:
                    return new StoreViewOrders(new StoreBL(new StoreRepository(new StorefrontDL.Entities.P0DBContext())));
                case PageType.CustomerViewOrders:
                    return new CustomerViewOrders(new CustomerBL(new CustomerRepository(new StorefrontDL.Entities.P0DBContext())));
                default:
                    return null;
            }
        }
    }
}