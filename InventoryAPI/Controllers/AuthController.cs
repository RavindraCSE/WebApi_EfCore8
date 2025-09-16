using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Services.Concrete;
using Services.Contract;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public AuthController(ITokenGeneratorService tokenGeneratorService)
        {
            _tokenGeneratorService= tokenGeneratorService;
        }
        [HttpGet]
        [AllowAnonymous] // this method will generate the token 
        public IActionResult ValidateUser(string username, string password)
        {
            // call the database to validate user name & password
            if(username=="test" && password=="test")
            {
                ValidateUserModel model = new ValidateUserModel() 
                {
                EmailAddress="user@gmail.com",
                Roles="User",
                UserId=1
                };
                // you are a valid user and generate a token
                var accessToken = _tokenGeneratorService.GenerateToken(model);
                var accessTokenModel = new TokenResponseModel()
                {
                    AccessToken = accessToken
                };
                return Ok(accessTokenModel);
            }
            return BadRequest("Invalid");
        }
    }
}
