using StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Abstruction.Services.Identity
{
    public interface ILoginService
    {
        Task<LoginUserResponse> Login(LoginUserRequest loginRequest);
    }
}
