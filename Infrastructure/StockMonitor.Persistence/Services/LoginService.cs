using Azure.Core;
using Microsoft.AspNetCore.Identity;
using StockMonitor.Application.Abstruction.Services.Identity;
using StockMonitor.Application.Abstruction.Token;
using StockMonitor.Application.Features.Identity.AppUser.Commads.LoginUser;
using StockMonitor.Application.Models;
using StockMonitor.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace StockMonitor.Persistence.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
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
    }
}
