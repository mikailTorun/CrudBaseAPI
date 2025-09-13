using StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser;
using StockMonitor.Domain.Entities.Common;

namespace StockMonitor.Application.Abstruction.Services.Identity
{
    public interface IAppUserService
    {
        Task<CreateAppUserCommandResponse> CreateUser(CreateAppUserCommandRequest userRequest);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenLifeTime, int refreshTokenTime);


        
    }
}
