using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChatApplication.BLL.Dto.JwtToken;
using ChatApplication.BLL.Response;
using ChatApplication.BLL.Service.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ChatApplication.BLL.Service.Implementation;

public class TokenService : ITokenService
{
    public async Task<JwtTokenResponse> GenerateToken(TokenRequest tokenRequest, IConfiguration configuration)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret"] ?? throw new InvalidOperationException()));
            
        var dateTimeNow = DateTime.Now;
        var expireMinute = int.Parse(configuration["Jwt:Expire"] ?? throw new InvalidOperationException());
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, tokenRequest.Email)
        };
            
        var jwt = new JwtSecurityToken(
            issuer: configuration["Jwt:ValidIssuer"],
            audience: configuration["Jwt:ValidAudience"],
            claims: claims,
            notBefore: dateTimeNow,
            expires: dateTimeNow.AddMinutes(expireMinute),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );
            
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        var expireDate = dateTimeNow.AddMinutes(expireMinute);
    
        return await Task.FromResult(new JwtTokenResponse()
        {
            Token = token,
            ExpireDate = expireDate
        });
    }
}