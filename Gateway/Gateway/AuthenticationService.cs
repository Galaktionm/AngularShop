using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Gateway
{
    public class AuthenticationService
    {
        private readonly IConfiguration configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> validateTokenAsync(StringValues tokenStringValues)
        {

            string token=tokenStringValues.ToString().Split(' ')[1];

            var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecurityKey"]);
            var secret = new SymmetricSecurityKey(key);
            TokenValidationParameters parameters = new TokenValidationParameters();
            parameters.IssuerSigningKey = secret;
            parameters.ValidIssuer = configuration["JwtSettings:Issuer"];
            parameters.ValidAudience = configuration["JwtSettings:Audience"];

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var result=await handler.ValidateTokenAsync(token, parameters);

            if(result.IsValid)
            {
                return true;
            }

              return false;
        }
    }
}
