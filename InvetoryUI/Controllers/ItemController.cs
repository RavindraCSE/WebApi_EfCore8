using InvetoryUI.Models;
using InvetoryUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvetoryUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
       // private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemController(IHttpClientFactory clientFactory )
            //IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
           // _httpContextAccessor= httpContextAccessor;


        }
        public async Task<IActionResult> Index(int id)
        {
            var client = _clientFactory.CreateClient("InventoryAPIClient");

            //var token = _httpContextAccessor.HttpContext.Request.Cookies["AccessToken"];
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var items = await client.GetFromJsonAsync<ApiResponseModel<ItemViewModel>>($"api/Item/getItemByCategory/{id}");
            return View(items.Data);
        }
    }
}
