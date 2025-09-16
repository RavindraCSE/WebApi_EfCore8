using InvetoryUI.Helpers;

namespace InvetoryUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add service to call the API in UI Project

            builder.Services.AddHttpContextAccessor();

            //builder.Services.AddHttpClient("InventoryAPIClient", options =>
            //{
            //    options.BaseAddress = new Uri(builder.Configuration["InventoryAPI:Url"]!);
            //    options.DefaultRequestHeaders.Add("Accept", "application/json"); // content negotiation 

            //});

            builder.Services.AddScoped<TokenHandler>();

            builder.Services.AddHttpClient("InventoryAPIClient", options => 
            {
                options.BaseAddress = new Uri(builder.Configuration["InventoryAPI:Url"]!);
                options.DefaultRequestHeaders.Add("Accept", "application/json"); // content negotiation 

            }). AddHttpMessageHandler<TokenHandler>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
