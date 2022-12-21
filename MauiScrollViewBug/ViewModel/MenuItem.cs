namespace MauiScrollViewBug.ViewModel
{
    public class MenuItem
    {
        public List<MenuSubItem> SubItems { get; set; }
    }
    public class MenuSubItem
    {
        public string IconName { get; set; }
        public string Title { get; set; }
    }
}
