using Azure.Core;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Features.Identity.Customer.Commads;
using StockMonitor.Application.Features.Identity.Customer.Queries.GetAllCustomerQuery;
using StockMonitor.Application.Repositories.Identity;
using StockMonitor.Domain.Entities.Identity;
using StockMonitor.Persistence.Repositories.Identity;

namespace StockMonitor.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public CustomerService(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<CreateCustomerCommandResponse> CreateCustomerAsync(CreateCustomerCommandRequest createCustomerRequest)
        {
            Customer entity = new()
            {
                Address = createCustomerRequest.Address,
                Name = createCustomerRequest.Name,
                Email = createCustomerRequest.Email,
                Phone = createCustomerRequest.Phone,
                CreatedDate = DateTime.UtcNow
            };
            var savedCustomer = await _customerWriteRepository.AddAsync(entity);
            await _customerWriteRepository.SaveAsync();
            return new(){ IsSucceed = savedCustomer };
        }

        public GetAllCustomerQueryResponse GetAll()
        {
            var allCustomer = _customerReadRepository.GetAll().ToList();
            return new GetAllCustomerQueryResponse { Customers = allCustomer };
        }
    }
}
