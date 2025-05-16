using Microsoft.EntityFrameworkCore;
using NFTMVC.BL.Services;
using NFTMVC.DAL.Contexts;
using NFTMVC.DAL.Models;

namespace NFTMVC.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            string? connectstr = builder.Configuration.GetConnectionString("PC");

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectstr));
            builder.Services.AddScoped<CollectionsService>();



            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                
                name:"Default",
                pattern:"{controller=Home}/{action=Index}"
                
                );

            

            app.Run();
        }
    }
}
