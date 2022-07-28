using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    // options.RequireHttpsMetadata = false;
                    // options.Authority = "https://sts.skoruba.local/";
                    // options.Audience =  "app.api";
                    options.MetadataAddress = "https://sts.skoruba.local" + "/.well-known/openid-configuration";

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "https://sts.skoruba.local",
                        ValidAudience = "app.api",
                        
                    };
                });

            return services;
        }
    }
}