using StockMonitor.Domain.Entities.Common;

namespace StockMonitor.Application.Abstruction.Token
{
    public interface ITokenHandler
    {
        Task<Application.Models.Token> GenerateAccessTokenAsync(int min, AppUser user);
        string GenerateRefreshToken();
    }
}
