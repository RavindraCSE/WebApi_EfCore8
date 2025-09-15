using AutoMapper;
using Data;
using Data.Contract;
using Microsoft.AspNetCore.Mvc;
using Models.Items.Request;
using Models.Items.Response;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        //public ItemService(IItemRepository itemRepository)
        //{
        //    _itemRepository = itemRepository;
            
        //}
        public ItemService(IItemRepository itemRepository , IMapper mapper)
        {
           _itemRepository = itemRepository;
            _mapper=mapper;
        }


        public bool AddItems(AddItemRequestModel requestModel)
        {
            var itemCategory = _mapper.Map<ItemCategory>(requestModel);
            return _itemRepository.AddItems(itemCategory);

        }


        //public bool AddItems( AddItemRequestModel requestModel)
        //{
        //    var items = new List<Item>();
        //    foreach(var item in requestModel.Items)
        //    {
        //        items.Add(new Item() 
        //        { 
        //        ItemName= item.ItemName,
        //        ItemDescription= item.ItemDescription,
        //        });
        //    }

        //    var itemCategory = new ItemCategory()
        //    {
        //        CategoryName = requestModel.CategoryName
        //    };

        //   return _itemRepository.AddItems(itemCategory, items);

        //}

        //public List<GetItemsByCategoryResponseModel> GetItems()
        //{
        //    List<GetItemsByCategoryResponseModel> responseModels = new List<GetItemsByCategoryResponseModel>();
        //    responseModels.Add(new GetItemsByCategoryResponseModel()
        //    {
        //        ItemDescription = "Laptop",
        //        ItemName = "New Laptop Silver Screen",
        //        ItemType = "Electronics"
        //    });
        //    return responseModels;
        //}

        //    public async Task<GetItemsByCategoryResponseModel> GetItemsByCategoryAsync(int categoryId)
        //    {
        //        var data= await _itemRepository.GetItemsByCategoryAsync(categoryId);
        //        if (data == null)
        //            throw new Exception($"No Categories found against {categoryId}");
        //        GetItemsByCategoryResponseModel reponse = new();
        //        reponse.CategoryName = data.CategoryName;
        //        foreach( var item in data.Items)
        //        {
        //            ItemResponseModel responseModel = new() 
        //            {
        //                ItemDescription= item.ItemDescription,
        //                ItemName= item.ItemName
        //            };
        //            reponse.Items.Add(responseModel);
        //        }
        //        return reponse;

        //    }

        public async Task<GetItemsByCategoryResponseModel> GetItemsByCategoryAsync(int categoryId)
        {
            var data = await _itemRepository.GetItemsByCategoryAsync(categoryId);
            if (data == null) throw new Exception($"No Categories found against {categoryId}");
            // now manual mapping is not needed
            var reponse = _mapper.Map<GetItemsByCategoryResponseModel>(data);


            return reponse;

        }

    }
}
