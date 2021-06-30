using System;
using StorefrontModels;

namespace StorefrontUI
{
    class Program
    {   
        static void Main(string[] args)
        {
            ISelectionPage storePage = new MainPage();
            PageType currentPage = PageType.MainPage;
            bool repeat = true;
            while (repeat){
                Console.Clear();
                storePage.Page();
                currentPage = storePage.Selection();
                switch(currentPage){
                    case PageType.CustomerPage:
                        storePage= new CustomerPage();
                        break;
                    case PageType.StorePage:
                        storePage= new StorePage();
                        break;
                }
                }
            }
        }
    }


}