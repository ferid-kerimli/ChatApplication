using ChatApplication.BLL.Dto.Authentication;
using ChatApplication.BLL.Response;
using Microsoft.Extensions.Configuration;

namespace ChatApplication.BLL.Service.Abstraction;

public interface IAuthenticationService
{
    Task<ApiResponse<JwtTokenResponse>> Login(LoginDto loginDto, IConfiguration configuration);
    Task<ApiResponse<RegisterDto>> Register(RegisterDto registerDto);
    Task<ApiResponse<bool>> Logout();
}