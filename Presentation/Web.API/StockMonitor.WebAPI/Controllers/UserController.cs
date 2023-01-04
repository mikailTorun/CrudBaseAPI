using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMonitor.Application.Features.Identity.AppUser.Commads;
using StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser;
using StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser;

namespace StockMonitor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //[Route("GetUserById")]
        //public async Task<GetUserQueryResponse> GetUserByIdAsync([FromBody] GetUserQueryRequest getUserQueryRequest)
        //{
        //    GetUserQueryResponse response = await _mediator.Send(getUserQueryRequest);
        //    return response;
        //}
        [HttpPost]
        [Route("CreateUserAsync")]
        public async Task<IActionResult> CreateUserAsync(CreateAppUserCommandRequest user)
        {
            CreateAppUserCommandResponse response = await _mediator.Send(user);
            return Ok(response);

        }

        //[HttpGet]
        //[Route("GetAllUserAsync")]
        //public async Task<ActionResult<GetAllUserQueryResponse>> GetAllUserAsync()
        //{
        //    //GetAllUserQueryResponse response = await _mediator.Send(new GetAllUserQueryRequest());
        //    return Ok(await _mediator.Send(new GetAllUserQueryRequest()));
        //}
    }
}
