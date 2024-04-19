using WebApi.Modules.User.Infrastructure.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel;
using WebApi.Configurations;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Persistence;
using WebApi.Infrastructure.Extensions;
using WebApi.Application.Extensions;
using WebApi.Domain.Abstractions;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.AddControllers();
builder.Services.AddSwaggerModule();
builder.Services.AddInfrastructureUser(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDatabaseModule<UserDbContext>(builder.Configuration);
builder.Services.AddDatabaseModule<CustomerSupportDatabaseContext>(builder.Configuration);
builder.Services.AddScoped<ICustomerSupportDbContext, CustomerSupportDatabaseContext>();
builder.Services.AddMediatR(c=>c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatRModule(builder.Configuration);
builder.Services.AddIdentityJwt(builder.Configuration);
builder.Services.AddMailModule(builder.Configuration);
builder.Services.SetupHealthCheck();


var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApplicationCors(builder.Services, builder.Configuration);

app.UseHttpsRedirection();
app.ConfigureHealthCheck();
//app.UseMiddleware<LoggingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
