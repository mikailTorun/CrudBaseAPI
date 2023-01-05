using StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser;

namespace StockMonitor.Application.Abstruction.Services.Identity
{
    public interface ILoginService
    {
        Task<LoginUserResponse> Login(LoginUserRequest loginRequest);
        Task<StockMonitor.Application.Models.Token> RefreshTokenLogin(string refreshTokenLoginRequest);
    }
}
