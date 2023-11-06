using BackendApi.ApiTech.Domain.Repositories;
using BackendApi.ApiTech.Domain.Services;
using BackendApi.ApiTech.Services;
using BackendApi.Shared.Persistence.Contexts;
using BackendApi.Shared.Persistence.Repositories;
using BackendApi.ApiTech.Persistence.Repositories;
using BackendApi.Security.Domain.Repositories;
using BackendApi.Security.Domain.Services.Communication;
using BackendApi.Security.Persistence.Repository;
using BackendApi.Security.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at 
https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnalyticRepository, AnalyticsRepository>();
builder.Services.AddScoped<IAnalyticService, AnalyticService>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(BackendApi.ApiTech.Mapping.ModelToResourceProfile), 
    typeof(BackendApi.Security.Mapping.ModelToResourceProfile),
    typeof(BackendApi.ApiTech.Mapping.ResourceToModelProfile),
    typeof(BackendApi.Security.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();