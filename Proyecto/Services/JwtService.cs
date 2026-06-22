using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Models;
using Proyecto.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto.Services
{
    public class JwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Us_Id.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.Us_Name),

                new Claim(
                    ClaimTypes.Email,
                    user.Us_Email),

                new Claim(
                    "RoleId",
                    user.Rol_Id.ToString())
            };

            // Agregar nombre del rol si existe
            if (user.Role != null)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        user.Role.Rol_Name)); // Ajustar al nombre real de la propiedad
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(
                _jwtSettings.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
