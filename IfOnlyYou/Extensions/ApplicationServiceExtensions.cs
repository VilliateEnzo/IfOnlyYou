using IfOnlyYou.IServices;
using IfOnlyYou.Services;
using IfOnlyYouDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace IfOnlyYou.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUsersService, UsersService>(); //or AddTransient
            services.AddScoped<IAccountService, AccountService>(); //or AddTransient
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Default"));
            });

            return services;
        }
    }
}
