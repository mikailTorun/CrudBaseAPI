using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser
{
    public class CreateAppUserCommandResponse
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
