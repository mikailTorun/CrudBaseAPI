using StockMonitor.Application.Features.Identity.Customer.Commads;
using StockMonitor.Application.Features.Identity.Customer.Queries.GetAllCustomerQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Abstruction.Services.Identity
{
    public interface ICustomerService
    {
        GetAllCustomerQueryResponse GetAll();
        Task<CreateCustomerCommandResponse> CreateCustomerAsync(CreateCustomerCommandRequest createCustomerRequest);
    }
}
