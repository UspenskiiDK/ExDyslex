using Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Logging;

namespace Common
{
    public class Helpers
    {
        public static string GenerateHashPassword(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public static bool VerifyHashPassword(string password, string hashPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashPassword);

        public static string GenerateJwtToken(Client client)
        {
            var _secretKey = "lbvf2ghjrcbuhjr6ikyhntgbqwcvbghdk56slssdsdssnfksf343ksadfaf";

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
                SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("clientId", client.Id.ToString()),
                new Claim("clientEmail", client.Email)
            };

            var token = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(12),
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;
            validationParameters.ValidateAudience = false;
            validationParameters.ValidateIssuer = false;

            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("lbvf2ghjrcbuhjr6ikyhntgbqwcvbghdk56slssdsdssnfksf343ksadfaf"));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);


            return principal;
        }
    }
}
