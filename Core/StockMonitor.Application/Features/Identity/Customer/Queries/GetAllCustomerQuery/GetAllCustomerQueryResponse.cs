using C = StockMonitor.Domain.Entities.Identity;
namespace StockMonitor.Application.Features.Identity.Customer.Queries.GetAllCustomerQuery
{
    public class GetAllCustomerQueryResponse
    {
        public List<C.Customer> Customers { get; set; }
    }
}
