using DesafioTecnicoFSBR.Api.Configuration.MigrationConfiguration;
using DesafioTecnicoFSBR.Api.Middlewares;
using DesafioTecnicoFSBR.Application.Features.Car.Commands.Create;
using DesafioTecnicoFSBR.Identity.Models;
using DesafioTecnicoFSBR.Infra;
using DesafioTecnicoFSBR.Infra.Contexts;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;

builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
        policy.RequireAuthenticatedUser());
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter("DefaultPolicy"));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssemblyContaining<CreateCarCommand>();
});

builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.ApplyInfraConfiguration(connectionString);

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseCors("AllowSpecificOrigin");
app.UseMiddleware<CurrentUserMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapGroup("api/Identity").MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
