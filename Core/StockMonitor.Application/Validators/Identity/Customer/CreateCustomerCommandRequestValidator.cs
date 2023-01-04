using FluentValidation;
using StockMonitor.Application.Features.Identity.Customer.Commads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Validators.Identity.Customer
{
    public class CreateCustomerCommandRequestValidator : AbstractValidator<CreateCustomerCommandRequest>
    {
        public CreateCustomerCommandRequestValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull().WithMessage("Plesase enter the Name input")
                .MaximumLength(400)
                .MinimumLength(2)
                .WithMessage("Comnpany name length is must be between 2 and 150"); // sayısal değerlerde min max vereceksek .must kullan
        }
    }
}
