using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Items.Response
{
    public class GetItemsByCategoryResponseModel
    {
        //public string ItemName { get; set; }
        //public string ItemType { get; set; }
        //public string ItemDescription { get; set; }

        public GetItemsByCategoryResponseModel()
        {
            Items = [];
        }
        public string CategoryName { get; set; }
        public List<ItemResponseModel> Items{get;set;}
    }
    public class ItemResponseModel
    {
        public string ItemName {  get; set; }
        public string ItemDescription { get; set; }
    }
}
