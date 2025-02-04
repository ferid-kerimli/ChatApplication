using ChatApplication.BLL.Dto.JwtToken;
using ChatApplication.BLL.Response;
using Microsoft.Extensions.Configuration;

namespace ChatApplication.BLL.Service.Abstraction;

public interface ITokenService
{
    Task<JwtTokenResponse> GenerateToken(TokenRequest tokenRequest, IConfiguration configuration);
}