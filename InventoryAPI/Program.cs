
using Data;
using Data.Concrete;
using Data.Contract;
using InventoryAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Concrete;
using Services.Contract;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Serilog;

namespace InventoryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Add Logger after nuget installation
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("Logger/ApplicationLog-.txt")
                        .Enrich.FromLogContext()
                        .MinimumLevel.Information()
                        .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // use serilog 
            builder.Host.UseSerilog();

            // Passed the reference of the data project over here
            builder.Services.AddDbContext<InvetoryDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
            });

            // install nuget for versioning and add service here
            builder.Services.AddApiVersioning(options => {
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified= true;
                options.ReportApiVersions = true;
            
            });
            // register service for JWT token 01
            // this will authenticate the token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Secret"]!)),
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ClockSkew=TimeSpan.Zero,
                    };
        
                });

             builder.Services.AddControllers();

            // for content negotialtion 01
            //builder.Services.AddControllers().AddXmlSerializerFormatters();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IItemService, ItemService>();
            builder.Services.AddTransient<IItemRepository, ItemRepository>();
            builder.Services.AddTransient<ITokenGeneratorService,TokenGeneratorService>();

            // register the assembly for the auto mapper to work 
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // add middleware for  JWT token 02
            app.UseAuthentication();

            app.UseAuthorization();

            // call the custom middleware 
            //comment for   for content negotialtion 02 & 01 at top uncomment
            app.UseMiddleware<CommonResponseMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
