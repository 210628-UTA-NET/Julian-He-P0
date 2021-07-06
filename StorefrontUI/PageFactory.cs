using StorefrontBL;
using StorefrontDL;
using System;


namespace StorefrontUI
{
    public class PageFactory : IPageFactory
    {
        public ISelectionPage GetMenu(PageType p_menu)
        {
            switch (p_menu)
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
                default:
                    return null;
            }
        }
    }
}