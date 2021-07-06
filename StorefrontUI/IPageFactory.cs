namespace StorefrontUI
{
    public interface IPageFactory
    {
        ISelectionPage GetMenu(PageType p_menu);
    }
}