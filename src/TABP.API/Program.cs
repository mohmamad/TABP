using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;
using System.Text;
using TABP.API.CQRS.Handlers;
using TABP.API.Logging;
using TABP.API.Profiles;
using TABP.Application.Profiles;
using TABP.Infrastructure;
using TABP.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TABPDbContext>(options =>
{
    string connectionString = builder.Configuration["ConnectionStrings:SqlServerConnectionString"];
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(RequestResponseLoggingFilter));
})
.AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/ecotrack.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(UserModelProfile).Assembly);
builder.Services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<TABPDbContext>();

var key = Encoding.ASCII.GetBytes(builder.Configuration["Authentication:Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = true
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
