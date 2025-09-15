using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IItemService _itemService;
        public EmployeeController(IItemService itemService)
        {
            _itemService= itemService;
        }

        [HttpGet]
        [Route("getemployees")]
        public IActionResult Get() 
        {
            var enpplyee = new { FirstName = "Rahj", LastName = "Kumar" };
            return Ok(enpplyee);
        
        }

        //[HttpGet]
        //public IActionResult GetItems()
        //{
        //    var items = _itemService.GetItems();
        //    return Ok(items);
        //}
    }
}
