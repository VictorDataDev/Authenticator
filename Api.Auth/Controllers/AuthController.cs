using Api.Auth.Models.Request;
using Api.Auth.Models.Response;
using Api.Auth.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult GetToken([FromBody] AuthRequest request)
        {
            var token = _tokenService.GetToken(request);

            if (string.IsNullOrEmpty(token))
                return BadRequest();

            return Ok(
                new AuthResponse
                {
                    Token = token
                });
        }

        [HttpPost]
        [Route("refresh")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult RefreshToken([FromBody] RefreshAuthRequest request)
        {
            var token = _tokenService.RefreshToken(request);

            if (string.IsNullOrEmpty(token))
                return BadRequest();

            return Ok(
                new AuthResponse
                {
                    Token = token
                });
        }
    }
}
