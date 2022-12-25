using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models.DTO;
using Web.Api.Repositories;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            // check if user is Auhenticated
            var user = await userRepository.AuthenticateAsync(loginRequest.Username
                , loginRequest.Password);
            if (user != null)
            {
                // generate a jwt token      
                var token = await tokenHandler.GetTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect");
        }
    }
}
