using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Features.Identity.Customer.Commads
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}
