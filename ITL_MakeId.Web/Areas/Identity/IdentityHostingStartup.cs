using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ITL_MakeId.Web.Areas.Identity.IdentityHostingStartup))]
namespace ITL_MakeId.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}