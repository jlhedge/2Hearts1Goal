using _2Hearts1Goal.Modules.Users.Application.Contracts;
using _2Hearts1Goal.Modules.Users.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Users.Presentation;

public static class UsersModuleEndpointRouteBuilderExtensions
{
    public static IServiceCollection AddUsersPresentation(this IServiceCollection services)
    {
        services.AddUsersModule();
        return services;
    }

    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/users").WithTags("Users");

        group.MapPost(
            "/",
            async (CreateUserRequest request, IUserService userService, CancellationToken cancellationToken) =>
            {
                var user = await userService.CreateAsync(request, cancellationToken);
                return Results.Created($"/api/users/{user.UserId}", user);
            });

        group.MapGet(
            "/by-account/{accountId:guid}",
            async (Guid accountId, IUserService userService, CancellationToken cancellationToken) =>
            {
                var user = await userService.GetByAccountIdAsync(accountId, cancellationToken);
                return user is null ? Results.NotFound() : Results.Ok(user);
            });

        group.MapPut(
            "/settings",
            async (UpdateUserSettingsRequest request, IUserService userService, CancellationToken cancellationToken) =>
            {
                var user = await userService.UpdateSettingsAsync(request, cancellationToken);
                return user is null ? Results.NotFound() : Results.Ok(user);
            });

        return endpoints;
    }
}
