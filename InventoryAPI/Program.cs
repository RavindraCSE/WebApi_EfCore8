
using Data;
using Data.Concrete;
using Data.Contract;
using InventoryAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Services.Concrete;
using Services.Contract;
using System.Reflection;

namespace InventoryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Passed the reference of the data project over here
            builder.Services.AddDbContext<InvetoryDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
            });

            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IItemService, ItemService>();
            builder.Services.AddTransient<IItemRepository, ItemRepository>();


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

            app.UseAuthorization();

            // call the custom middleware 
            app.UseMiddleware<CommonResponseMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
