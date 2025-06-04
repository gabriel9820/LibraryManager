using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Auth;
using LibraryManager.Infrastructure.Persistence;
using LibraryManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddLibraryManagerDbContext(configuration)
            .AddRepositories()
            .AddAuthentication();

        return services;
    }

    private static IServiceCollection AddLibraryManagerDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryManagerDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("LibraryManagerDb")));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
