using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using QLBanHang.Data;

[assembly: HostingStartup(typeof(QLBanHang.Areas.Identity.IdentityHostingStartup))]
namespace QLBanHang.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) => {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("DefaultConnection")));
        });
    }
}
