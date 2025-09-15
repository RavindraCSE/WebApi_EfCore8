using Models.Items.Request;
using Models.Items.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IItemService
    {
        //List<GetItemsByCategoryResponseModel> GetItems();


        Task<GetItemsByCategoryResponseModel> GetItemsByCategoryAsync(int categoryId);

        bool AddItems(AddItemRequestModel requestModel);
    }
}
