  namespace StorefrontUI{


    public enum PageType
    {
        MainPage,
        StorePage,
        CustomerPage,
        Exit
    }
    public interface ISelectionPage{
        void Page();

        PageType Selection();

    }

  }