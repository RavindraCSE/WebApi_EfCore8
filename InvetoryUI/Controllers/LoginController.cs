using InvetoryUI.Models;
using InvetoryUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvetoryUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IHttpClientFactory clientFactory , IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor= httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login) 
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("InventoryAPIClient");
                var userResponse = await client.GetFromJsonAsync<ApiResponseModel<ValidateApiResponse>>($"api/Auth?username={login.UserName}&password={login.Password}"); 
                if(userResponse.Success)
                {
                    var access_token = userResponse.Data.AccessToken;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("AccessToken", access_token, new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(60),
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Lax

                    });
                    return RedirectToAction("Index","Item", new { id=2});
                }

            }
            return View(login);
        
        }
    }

    public class ValidateApiResponse
    {
        public string AccessToken { get;set; }
    }
}
