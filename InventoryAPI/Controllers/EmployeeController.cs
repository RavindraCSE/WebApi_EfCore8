using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]

    // By enabling the below comment we can run versioing api in post man 
    // url : {{host_address}}/api/v1/employee/getemployees
    // [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("1.0")]
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

    //[Route("api/v{version:apiVersion}/employee")]
    //[ApiVersion("2.0")]
    //[ApiController]
    //public class EmployeeV2Controller : ControllerBase
    //{
    //    private readonly IItemService _itemService;
    //    public EmployeeV2Controller(IItemService itemService)
    //    {
    //        _itemService = itemService;
    //    }

    //    [HttpGet]
    //    [Route("getemployees")]
    //    public IActionResult Get()
    //    {
    //        var enpplyee = new { FirstName = "Rahj", LastName = "Kumar" };
    //        return Ok(enpplyee);

    //    }

    //    //[HttpGet]
    //    //public IActionResult GetItems()
    //    //{
    //    //    var items = _itemService.GetItems();
    //    //    return Ok(items);
    //    //}
    //}
}
