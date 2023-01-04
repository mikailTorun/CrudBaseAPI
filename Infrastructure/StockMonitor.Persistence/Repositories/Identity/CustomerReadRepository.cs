using StockMonitor.Application.Repositories.Identity;
using StockMonitor.Domain.Entities.Identity;
using StockMonitor.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Persistence.Repositories.Identity
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(StockMonitorDbContext context) : base(context)
        {
        }
    }
}
