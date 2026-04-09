using _2Hearts1Goal.Application;
using _2Hearts1Goal.Infrastructure;
using _2Hearts1Goal.Modules.Accounts.Presentation;
using _2Hearts1Goal.Modules.Matchmaking.Presentation;
using _2Hearts1Goal.Modules.Messaging.Presentation;
using _2Hearts1Goal.Modules.Search.Presentation;
using _2Hearts1Goal.Modules.Subscriptions.Presentation;
using _2Hearts1Goal.Modules.Users.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAccountsPresentation(builder.Configuration);
builder.Services.AddSubscriptionsPresentation();
builder.Services.AddMatchmakingPresentation();
builder.Services.AddMessagingPresentation();
builder.Services.AddSearchPresentation();
builder.Services.AddUsersPresentation();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "Frontend",
        policy =>
        {
            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            if (allowedOrigins is { Length: > 0 })
            {
                policy.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("Frontend");
app.MapAccountsEndpoints();
app.MapUsersEndpoints();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
