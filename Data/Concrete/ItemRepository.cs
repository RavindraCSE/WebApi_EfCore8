using Data.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class ItemRepository : IItemRepository
    {
        private readonly InvetoryDbContext _dbContext;

        public ItemRepository(InvetoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddItems(ItemCategory itemCategory)
        {
            
            _dbContext.ItemsCategories.Add(itemCategory);
            int rowsAffected = _dbContext.SaveChanges();
            return rowsAffected > 0;
        }

        //public bool AddItems(ItemCategory itemCategory, List<Item> items)
        //{
        //  itemCategory.Items = items;
        //_dbContext.ItemsCategories.Add(itemCategory);
        //int rowsAffected = _dbContext.SaveChanges();
        //    return rowsAffected > 0;
        //}

        public async Task<ItemCategory> GetItemsByCategoryAsync(int categoryId)
        {
            var ItemCategory= await _dbContext.ItemsCategories
                                        .Include(x=>x.Items)
                                        .FirstOrDefaultAsync(x=>x.Id==categoryId);
            return ItemCategory;
        }
    }
}
