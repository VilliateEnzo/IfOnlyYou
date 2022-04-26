using IfOnlyYou.IServices;
using IfOnlyYou.Services;
using IfOnlyYouDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using IfOnlyYouDataAccessLibrary.Helpers;

namespace IfOnlyYou.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBuggyService, BuggyService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Default"));
            });

            return services;
        }
    }
}
