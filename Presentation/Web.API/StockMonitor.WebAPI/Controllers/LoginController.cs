using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser;
using StockMonitor.Application.Features.Identity.AppUser.Commads.RefreshToken;

namespace StockMonitor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<LoginUserResponse> Login([FromBody] LoginUserRequest user)
        {
            LoginUserResponse response = await _mediator.Send(user);
            return response;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
        {
            RefreshTokenResponse token = await _mediator.Send(new RefreshTokenRequest() { RefreshToken = refreshToken });
            return Ok(token);
        }
    }
}
