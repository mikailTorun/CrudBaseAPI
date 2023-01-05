using MediatR;

namespace StockMonitor.Application.Features.Identity.AppUser.Commads.RefreshToken
{
    public class RefreshTokenRequest : IRequest<RefreshTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}
