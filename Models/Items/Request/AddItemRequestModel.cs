using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Items.Request
{
    public class AddItemRequestModel
    {
        public string CategoryName {  get; set; }
        public List<ItemRequestModel> Items { get; set; }
       
   
    }
    public class ItemRequestModel
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
