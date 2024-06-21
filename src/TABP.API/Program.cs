using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using sib_api_v3_sdk.Client;
using Square.Apis;
using Square;
using System.Reflection;
using System.Text;
using TABP.API.Logging;
using TABP.Application.CQRS.Handlers.CommandHandlers.UserHandlers;
using TABP.Domain.Interfaces;
using TABP.Infrastructure;
using TABP.Infrastructure.Repositories;
using TABP.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173", "http://localhost:8081")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

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

Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);

builder.Host.UseSerilog();
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelTypeRepository, HotelTypeRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IFeaturedDealsRepository, FeaturedDealsRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IAmenityRepository, AmenityRepository>();
builder.Services.AddScoped<IResestPasswordRepository, ResetPasswordRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddDbContext<TABPDbContext>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var senderEmail = builder.Configuration.GetSection("BrevoApi")["SenderEmail"];
var senderName = builder.Configuration.GetSection("BrevoApi")["SenderName"];
builder.Services.AddSingleton<IEmailService>(new EmailService(senderEmail, senderName));

var basePath = builder.Configuration.GetSection("ImageStorage")["BasePath"];
builder.Services.AddSingleton<IImageStorageService>(new ImageStorageService(basePath));

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

builder.Services.AddSingleton<IPaymentsApi>(sp =>
{
    var accessToken = builder.Configuration["Square:AccessToken"];
    var squareClient = new SquareClient.Builder()
    .BearerAuthCredentials(
        new Square.Authentication.BearerAuthModel.Builder(accessToken)
        .Build()
    )
    .Environment(builder.Environment.IsProduction() ? Square.Environment.Production : Square.Environment.Sandbox)
    .Build();

    return squareClient.PaymentsApi;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); // Use the configured CORS policy

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
