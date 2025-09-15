using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contract
{
    public interface IItemRepository
    {
       // bool AddItems(ItemCategory itemCategory, List<Item> items);
        bool AddItems(ItemCategory itemCategory);
       Task<ItemCategory> GetItemsByCategoryAsync(int categoryId);
    }
}
