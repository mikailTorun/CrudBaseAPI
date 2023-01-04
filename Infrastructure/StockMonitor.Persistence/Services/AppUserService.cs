using Azure.Core;
using Microsoft.AspNetCore.Identity;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser;
using StockMonitor.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateAppUserCommandResponse> CreateUser(CreateAppUserCommandRequest userRequest)
        {
            var result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                UserName = userRequest.Username,
                Email = userRequest.Email,
                CustomerId = userRequest.CustomerId,
                Name = userRequest.Name,
                Surname = userRequest.Surname,

            }, userRequest.Password);

            if (result.Succeeded)
            {
                return new()
                {
                    IsSucceeded = true,
                    Message = "Başarılı"
                };
            }
            else
            {
                return new()
                {
                    IsSucceeded = false,
                    Errors = result.Errors
                };
            }
        }
    }
}
