using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; } 
    }
}
