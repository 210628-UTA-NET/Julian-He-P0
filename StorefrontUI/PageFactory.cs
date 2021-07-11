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
                    return new ShowStorefrontPage(new StoreBL(new StoreRepository()));
                    
                case PageType.AddStorefrontPage:
                    return new AddStorefrontPage(new StoreBL(new StoreRepository()));
                case PageType.FindStorePage:
                    return new FindStorePage(new StoreBL(new StoreRepository()));
                case PageType.FindCustomerPage:
                    return new FindCustomerPage(new CustomerBL(new CustomerRepository()));
                case PageType.CustomerPage:
                    return new CustomerPage(new CustomerBL(new CustomerRepository()));
                case PageType.ShowCustomerPage:
                    return new ShowCustomerPage(new CustomerBL(new CustomerRepository()));
                case PageType.AddCustomerPage:
                    return new AddCustomerPage(new CustomerBL(new CustomerRepository()));
                
                default:
                    return null;
            }
        }
    }
}