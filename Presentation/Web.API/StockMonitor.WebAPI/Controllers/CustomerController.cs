using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMonitor.Application.Constants;
using StockMonitor.Application.Features.Identity.Customer.Commads;
using StockMonitor.Application.Features.Identity.Customer.Queries.GetAllCustomerQuery;

namespace StockMonitor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<CreateCustomerCommandResponse> CreateUser(CreateCustomerCommandRequest customer)
        {
            CreateCustomerCommandResponse response = await _mediator.Send(customer);
            return response;
        }
        [HttpGet]
        [Route("GetAllCustomerAsync")]
        [Authorize(Roles = AppUserRole.Admin)]
        public async Task<GetAllCustomerQueryResponse> GetAllCustomerAsync()
        {
            return await _mediator.Send(new GetAllCustomerQueryRequest());
        }
    }
}
