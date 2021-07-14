using System;

namespace StorefrontUI
{
    class Program
    {   
        static void Main(string[] args)
        {
            ISelectionPage storePage = new MainPage();
            PageType currentPage = PageType.MainPage;
            bool repeat = true;
            IPageFactory pageFactory = new PageFactory();
            while (repeat){
                Console.Clear();
                storePage.Page();
                currentPage = storePage.Selection();
                switch(currentPage){
                    case PageType.MainPage:
                        storePage=pageFactory.GetMenu(PageType.MainPage);
                        break;
                    case PageType.AddStorefrontPage:
                        storePage= pageFactory.GetMenu(PageType.AddStorefrontPage);
                        break;
                    case PageType.ShowCustomerPage:
                        storePage= pageFactory.GetMenu(PageType.ShowCustomerPage);
                        break;
                    case PageType.FindCustomerPage:
                        storePage= pageFactory.GetMenu(PageType.FindCustomerPage);
                        break;
                    case PageType.AddCustomerPage:
                        storePage = pageFactory.GetMenu(PageType.AddCustomerPage);
                        break;
                    case PageType.CustomerPage:
                        storePage= pageFactory.GetMenu(PageType.CustomerPage);
                        break;
                    case PageType.StorePage:
                        storePage= pageFactory.GetMenu(PageType.StorePage);
                        break;
                    case PageType.ReplenishInventory:
                        storePage = pageFactory.GetMenu(PageType.ReplenishInventory);
                        break;
                    case PageType.StoreOptions:
                        storePage = pageFactory.GetMenu(PageType.StoreOptions);
                        break;
                    case PageType.CustomerOptions:
                        storePage = pageFactory.GetMenu(PageType.CustomerOptions);
                        break;
                    case PageType.CustomerViewOrders:
                        storePage = pageFactory.GetMenu(PageType.CustomerViewOrders);
                        break;
                    case PageType.StoreViewOrders:
                        storePage = pageFactory.GetMenu(PageType.StoreViewOrders);
                        break;
                    case PageType.ViewInventory:
                        storePage = pageFactory.GetMenu(PageType.ViewInventory);
                        break;
                    case PageType.Exit:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Input not found, please try again. ");
                        break;
                }
            }
        }
    }
}

