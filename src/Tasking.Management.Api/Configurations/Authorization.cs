using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Tasking.Management.API.Configurations
{
    public static class Authorization
    {
        public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration cfg)
        {
            services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = cfg["Jwt:Issuer"],
                      ValidAudience = cfg["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(cfg["Jwt:Key"]!))
                  };
              });

            return services;
        }
    }
}
