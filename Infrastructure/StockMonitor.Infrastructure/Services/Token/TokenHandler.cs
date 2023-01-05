using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockMonitor.Application.Abstruction.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
            token.RefreshToken = GenerateRefreshToken();
            

            return token;
        }

        public string GenerateRefreshToken()
        {
            string guid = Guid.NewGuid().ToString().Replace("-","") + Guid.NewGuid().ToString().Replace("-","");
            byte[] bytes = Encoding.ASCII.GetBytes(guid.Replace("=",""));

            return Convert.ToBase64String(bytes);
        }
    }
}
