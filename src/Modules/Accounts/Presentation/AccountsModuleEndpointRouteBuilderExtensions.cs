using _2Hearts1Goal.Modules.Accounts.Application.Contracts;
using _2Hearts1Goal.Modules.Accounts.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Accounts.Presentation;

public static class AccountsModuleEndpointRouteBuilderExtensions
{
    public static IServiceCollection AddAccountsPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAccountsModule(configuration);
        return services;
    }

    public static IEndpointRouteBuilder MapAccountsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/accounts").WithTags("Accounts");

        group.MapPost(
            "/register",
            async (RegisterAccountRequest request, IAccountService accountService, CancellationToken cancellationToken) =>
            {
                var result = await accountService.RegisterAsync(request, cancellationToken);
                return Results.Created($"/api/accounts/sessions/{result.SessionToken}", result);
            });

        group.MapPost(
            "/login",
            async (LoginRequest request, IAccountService accountService, CancellationToken cancellationToken) =>
            {
                var result = await accountService.LoginAsync(request, cancellationToken);
                return result is null ? Results.Unauthorized() : Results.Ok(result);
            });

        return endpoints;
    }
}
