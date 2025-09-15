using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Items.Request;
using Models.Items.Response;
using Services.Contract;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Return Items from the database
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("getItems/{id:int}")] // passing the parameters
        //public IActionResult Get(int id)
        //{
        //    //IItemService service = new IItemService(); 
        //    //var items = service.GetItems();

        //    var items = _itemService.GetItems();
        //    return Ok(items);
        //}

        //[HttpGet]
        //[Route("getItemByCategory/{categoryId:int}")]
        //public async Task<IActionResult> Get(int categoryId)
        //{
        //    var items = await _itemService.GetItemsByCategoryAsync(categoryId);
        //    // for common output by API
          
        //     var apiResponseModel = new ApiResponseModel<GetItemsByCategoryResponseModel>(true, items,"Items Fetched successfully.");
        //     return Ok(apiResponseModel);
        //   // return Ok(items);
        //}

        [HttpGet]
        [Route("getItemByCategory/{categoryId:int}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            var items = await _itemService.GetItemsByCategoryAsync(categoryId);
            // for common output by API
            // commented as middle ware is used
           // var apiResponseModel = new ApiResponseModel<GetItemsByCategoryResponseModel>(true, items,"Items Fetched successfully.");
           // return Ok(items);
            return Ok(items);
        }

        

        [HttpPost]
        [Route("additems")]
        public IActionResult AddItems([FromBody]AddItemRequestModel requestModel)
        {
            var output = _itemService.AddItems(requestModel);
            // for common output by API
           // var apiResponseModel = new ApiResponseModel<bool>(true, output, "Items Added successfully");
            return Ok(output);
            //return Ok(output);
        }
    }
}
