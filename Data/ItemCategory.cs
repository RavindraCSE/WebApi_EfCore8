using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ItemCategory
    {
        public int Id { get; set; }
       
        public string CategoryName { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
