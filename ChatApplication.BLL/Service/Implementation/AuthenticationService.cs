using ChatApplication.BLL.Dto.Authentication;
using ChatApplication.BLL.Dto.JwtToken;
using ChatApplication.BLL.Response;
using ChatApplication.BLL.Service.Abstraction;
using ChatApplication.BLL.Utility;
using ChatApplication.DAL.Entity;
using ChatApplication.DAL.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace ChatApplication.BLL.Service.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(ITokenService tokenService, IUnitOfWork unitOfWork)
    {
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<JwtTokenResponse>> Login(LoginDto loginDto, IConfiguration configuration)
    {
        var response = new ApiResponse<JwtTokenResponse>()
        {
            Data = new JwtTokenResponse()
        };

        try
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(loginDto.Email);
            if (user == null)
            {
                response.Failure("Invalid email or password", 401);
                return response;
            }

            var passwordParts = user.Password.Split(':');
            if (passwordParts.Length != 2)
            {
                response.Failure("Invalid stored password format", 500);
                return response;
            }

            string salt = passwordParts[0];
            string storedHashedPassword = passwordParts[1];
            
            if (!PasswordHasher.VerifyPassword(loginDto.Password, salt, storedHashedPassword))
            {
                response.Failure("Invalid email or password", 401);
                return response;
            }

            var generatedToken =
                await _tokenService.GenerateToken(new TokenRequest { Email = loginDto.Email }, configuration);

            response.Data.Token = generatedToken.Token;
            response.Data.ExpireDate = generatedToken.ExpireDate;
                
            response.Success(response.Data, 200);
        }
        catch (Exception e)
        {
            response.Failure(e.Message, 500);
            throw;
        }
        
        return response;
    }

    public async Task<ApiResponse<RegisterDto>> Register(RegisterDto registerDto)
    {
        var response = new ApiResponse<RegisterDto>();

        try
        {
            var existingUser = await _unitOfWork.UserRepository.GetByEmail(registerDto.Email);
            if (existingUser != null)
            {
                response.Failure("User with this email already exists", 400);
                return response;
            }

            string salt = PasswordHasher.GenerateSalt();
            string hashedPassword = PasswordHasher.HashPassword(registerDto.Password, salt);
            
            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = $"{salt}:{hashedPassword}" 
            };

            await _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.SaveChanges();

            response.Success(registerDto, 201);
        }
        catch (Exception e)
        {
            response.Failure(e.Message, 500);
            throw;
        }
        
        return response;
    }

    public async Task<ApiResponse<bool>> Logout()
    {
        throw new NotImplementedException();
    }
}