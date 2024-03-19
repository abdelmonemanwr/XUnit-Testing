using Microsoft.EntityFrameworkCore;
using CarFactoryMVC.Entities;
using CarFactoryMVC.Services_BLL;
using CarFactoryMVC.Payment;
using CarFactoryMVC.Repositories_DAL;
namespace CarFactoryMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FactoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FactoryContext") ?? throw new InvalidOperationException("Connection string 'FactoryContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FactoryContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=UnitTest_Intake44_MNF;Trusted_Connection=True;TrustServerCertificate=True");
            });
            builder.Services.AddScoped<ICarsService, CarsService>();
            builder.Services.AddScoped<IOwnersService, OwnersService>();
            builder.Services.AddScoped<ICashService, CashService>();

            builder.Services.AddScoped<ICarsRepository, CarRepository>();
            builder.Services.AddScoped<IOwnersRepository, OwnerRepository>();

            builder.Services.AddSingleton<IInMemoryContext, InMemoryContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
