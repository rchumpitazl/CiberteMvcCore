using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

using System;

using System.Text;

namespace Cibertec.WebApi.Provider
{
    public static class AuthenticationOwin
    {
        private static readonly string secretKey =
            "clave_secreta_para_cifrado#2017";
        public static IApplicationBuilder UseSimpleToken(this 
            IApplicationBuilder app)
        {
            var signinKey = new
                SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var options = new TokenProviderOptions
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };
            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signinKey,
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });
            return app;
        }

    }
}
