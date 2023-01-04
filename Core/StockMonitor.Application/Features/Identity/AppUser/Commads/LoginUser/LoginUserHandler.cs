using MediatR;
using Microsoft.AspNetCore.Identity;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Abstruction.Token;
using StockMonitor.Application.Exceptions;
using StockMonitor.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common = StockMonitor.Domain.Entities.Common;
namespace StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly ILoginService _loginService;

        public LoginUserHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            return await _loginService.Login(request);
        }
    }
}
