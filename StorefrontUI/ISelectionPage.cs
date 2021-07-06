namespace StorefrontUI
{
    public enum PageType
    {
        MainPage,
        StorePage,
        CustomerPage,
        ShowStorefrontPage,
        AddStorefrontPage,
        Exit
    }
    public interface ISelectionPage{
        void Page();

        PageType Selection();

    }

  }