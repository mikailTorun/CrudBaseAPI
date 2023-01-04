using MediatR;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Repositories.Identity;

namespace StockMonitor.Application.Features.Identity.Customer.Queries.GetAllCustomerQuery
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
    {
        private readonly ICustomerService _customerService;

        public GetAllCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            return _customerService.GetAll();
        }
    }
}
