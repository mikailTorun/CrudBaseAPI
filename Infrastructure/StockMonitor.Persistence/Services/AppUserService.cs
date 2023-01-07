using Microsoft.AspNetCore.Identity;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Constants;
using StockMonitor.Application.Exceptions;
using StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser;
using StockMonitor.Domain.Entities.Common;

namespace StockMonitor.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppUserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateAppUserCommandResponse> CreateUser(CreateAppUserCommandRequest userRequest)
        {
            AppUser user = new()
            {
                Id = Guid.NewGuid(),
                UserName = userRequest.Username,
                Email = userRequest.Email,
                CustomerId = userRequest.CustomerId,
                Name = userRequest.Name,
                Surname = userRequest.Surname

            };
            var result = await _userManager.CreateAsync(user, userRequest.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(AppUserRole.Admin))
                    await _roleManager.CreateAsync(new AppRole() { Name = AppUserRole.Admin});
                if (!await _roleManager.RoleExistsAsync(AppUserRole.User))
                    await _roleManager.CreateAsync(new AppRole() { Name = AppUserRole.Admin });                
                if (!await _roleManager.RoleExistsAsync(AppUserRole.Manager))
                    await _roleManager.CreateAsync(new AppRole() { Name = AppUserRole.Admin });

                if (await _roleManager.RoleExistsAsync(AppUserRole.Admin))
                {
                    await _userManager.AddToRoleAsync(user, AppUserRole.Admin);
                }
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

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenLifeTime, int refreshTokenTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenLifeTime.AddMinutes(refreshTokenTime);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUSerException();
            }
            
            
        }
        
    }
}
