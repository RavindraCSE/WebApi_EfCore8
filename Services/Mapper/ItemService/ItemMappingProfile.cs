using AutoMapper;
using Data;
using Models.Items.Request;
using Models.Items.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.ItemService
{
    public class ItemMappingProfile :Profile
    {
        public ItemMappingProfile()
        {
            // ReverseMap() is very important when properties name differs from the 
            // source and the destination 
            CreateMap<ItemCategory, GetItemsByCategoryResponseModel>().ReverseMap();
            CreateMap<Item,ItemResponseModel>().ReverseMap();

            CreateMap<AddItemRequestModel, ItemCategory>();
            CreateMap<ItemRequestModel, Item>();

        }
        
    }
}
