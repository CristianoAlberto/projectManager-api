using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjectManagerApi.src.Infrastructure.Config;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace ProjectManagerApi.src.Infrastructure.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = new Jwtconfig
            {
                Secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "default_secret",  // Lê a variável do .env
                ExpiryMinutes = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRY_MINUTES") ?? "60"),  // Lê a variável do .env
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "default_issuer",  // Lê a variável do .env
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "default_audience"  // Lê a variável do .env
            };

            services.AddSingleton(jwtConfig);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtConfig.Issuer, // Obtém o Issuer do JwtConfig
                            ValidAudience = jwtConfig.Audience, // Obtém o Audience do JwtConfig
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)) // Chave secreta
                        };
                    });

            return services;
        }
    }
}
