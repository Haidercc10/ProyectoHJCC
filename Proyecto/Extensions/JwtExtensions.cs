using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Settings;
using System.Text;

namespace Proyecto.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            var jwtSection = configuration.GetSection("Jwt");

            var key = Encoding.UTF8.GetBytes(
                jwtSection["Key"]!);

            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer =
                                jwtSection["Issuer"],

                            ValidAudience =
                                jwtSection["Audience"],

                            IssuerSigningKey =
                                new SymmetricSecurityKey(key),

                            ClockSkew = TimeSpan.Zero
                        };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
