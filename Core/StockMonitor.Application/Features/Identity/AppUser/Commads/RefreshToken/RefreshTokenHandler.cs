using MediatR;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Models;

namespace StockMonitor.Application.Features.Identity.AppUser.Commads.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
    {
        private readonly ILoginService _loginService;

        public RefreshTokenHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            Token token = await _loginService.RefreshTokenLogin(request.RefreshToken);
            return new() { Token = token };
        }
    }
}
