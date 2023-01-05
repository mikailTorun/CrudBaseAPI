using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Abstruction.Token;
using StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser;
using StockMonitor.Application.Models;
using StockMonitor.Domain.Entities.Common;

namespace StockMonitor.Persistence.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IAppUserService _appUserService;

        public LoginService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IAppUserService appUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _appUserService = appUserService;
        }

        
        public async Task<LoginUserResponse> Login(LoginUserRequest loginRequest)
        {
            AppUser user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
            {
                return new() { IsSucceed = false, Message = "Kullanıcı Bulunamadı" };
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (result.Succeeded)// Authentication sağlandı
            {
                Token token = _tokenHandler.GenerateAccessToken(5);
                user.RefreshToken = token.RefreshToken;
                await _appUserService.UpdateRefreshToken(token.RefreshToken,user,token.Expiration,1);
                return new()
                {
                    IsSucceed = true,
                    Token = token
                };
            }
            return new()
            {
                IsSucceed = false,
                Message = "Kimlik doğrulama hatası"
            };
        }

        public async Task<Token> RefreshTokenLogin(string refreshTokenLoginRequest)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(x=> x.RefreshToken == refreshTokenLoginRequest);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.GenerateAccessToken(5);
                await _appUserService.UpdateRefreshToken(token.RefreshToken,user,token.Expiration,5);
                return token;
            }
            else
                throw new Exception("Token üretilemedi");
        }
    }
}
