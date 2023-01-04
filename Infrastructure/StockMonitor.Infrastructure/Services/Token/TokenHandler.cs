using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockMonitor.Application.Abstruction.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.Models.Token GenerateAccessToken(int min)
        {
            Application.Models.Token token = new();
            // sec. key in simetriği alınır
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            //şifrelenniş kimlik olusuturulur
            SigningCredentials signingCredentials = new(key,SecurityAlgorithms.HmacSha256);
            
            token.Expiration = DateTime.UtcNow.AddMinutes(min);
 
            JwtSecurityToken jwtSecurityToken = new(
                audience : _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore : DateTime.UtcNow,//üretildikten ne kadar sonra devreye girsin?. hemen olacak sekilde ayarladık
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken =  tokenHandler.WriteToken(jwtSecurityToken);


            return token;
        }

        public Application.Models.Token GenerateRefreshToken(int min)
        {
            Application.Models.Token token = new();
            // sec. key in simetriği alınır
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            //şifrelenniş kimlik olusuturulur
            SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(min);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,//üretildikten ne kadar sonra devreye girsin?. hemen olacak sekilde ayarladık
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);


            return token;
        }
    }
}
