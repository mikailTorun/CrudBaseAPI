using Microsoft.AspNetCore.Identity;
using StockMonitor.Application.Constants;
using StockMonitor.Domain.Enums;

namespace StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser
{
    public class CreateAppUserCommandResponse
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
        public string UserRole { get; set; }
    }
}
