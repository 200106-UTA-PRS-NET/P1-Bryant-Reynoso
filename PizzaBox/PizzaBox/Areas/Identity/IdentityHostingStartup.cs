using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaBox_Web.Data;

[assembly: HostingStartup(typeof(PizzaBox_Web.Areas.Identity.IdentityHostingStartup))]
namespace PizzaBox_Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PizzaBox_WebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PizzaBox_WebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PizzaBox_WebContext>();
            });
        }
    }
}