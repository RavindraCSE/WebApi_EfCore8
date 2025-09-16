namespace InvetoryUI.Models.ViewModels
{
    public class ItemViewModel
    {
        public string CategoryName { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }

}

