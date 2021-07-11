namespace StorefrontUI
{
    public enum PageType
    {
        MainPage,
        StorePage,
        CustomerPage,
        ShowStorefrontPage,
        ShowCustomerPage,
        AddStorefrontPage,
        FindStorePage,
        FindCustomerPage,
        AddCustomerPage,
        StoreOptions,
        CustomerOptions,
        ReplenishInventory,
        StoreViewOrders,
        CustomerViewOrders,
        ViewInventory,
        MakeOrder,
        Exit
    }
    public interface ISelectionPage{
        void Page();

        PageType Selection();

    }

  }