using FluentValidation;
using LibraryManager.Application.Commands.CreateBook;
using LibraryManager.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace LibraryManager.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR()
            .AddValidation();

        return services;
    }

    private static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateBookCommand>());

        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateBookValidator>()
            .AddFluentValidationAutoValidation();

        return services;
    }
}
