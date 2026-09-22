using HerkesYazarOlsun.Model.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HerkesYazarOlsun.Servis.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }

        public string GenerateToken(Users user)
        {
            var jwtSection = _configuration.GetSection("JwtSettings");
            var secretKey  = jwtSection["SecretKey"]!;
            var issuer     = jwtSection["Issuer"]!;
            var audience   = jwtSection["Audience"]!;
            var expMinutes = int.Parse(jwtSection["ExpirationMinutes"] ?? "1440");

            var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,   user.EMAIL ?? ""),
                new Claim(JwtRegisteredClaimNames.Email, user.EMAIL ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti,   Guid.NewGuid().ToString()),
                new Claim("user_id",    user.ID.ToString()),
                new Claim("email",      user.EMAIL    ?? ""),
                new Claim("username",   user.USERNAME ?? ""),
                new Claim("adi",        user.NAME     ?? ""),
                new Claim("soyadi",     user.SURNAME  ?? ""),
                new Claim("telno",      user.TELNO    ?? ""),
                new Claim("uygulama_id", "1")
            };

            var token = new JwtSecurityToken(
                issuer:             issuer,
                audience:           audience,
                claims:             claims,
                expires:            DateTime.UtcNow.AddMinutes(expMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public (string AccessToken, string RefreshToken) GenerateTokenPair(Users user)
        {
            var accessToken = GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            return (accessToken, refreshToken);
        }
    }
}
