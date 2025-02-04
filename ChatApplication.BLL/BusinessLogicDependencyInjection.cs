using ChatApplication.BLL.Service.Abstraction;
using ChatApplication.BLL.Service.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApplication.BLL;

public static class BusinessLogicDependencyInjection
{
    public static void BusinessLogicInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IMessageService, MessageService>();
    }
}