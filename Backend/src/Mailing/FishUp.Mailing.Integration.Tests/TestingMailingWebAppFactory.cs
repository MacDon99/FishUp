using FishUp.Mailing.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FishUp.Mailing.Integration.Tests
{
    public class TestingMailingWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : Startup
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<MailingDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                builder.UseStartup<MockStartup>();

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = serviceProvider.GetRequiredService<MailingDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<TestingMailingWebAppFactory<TStartup>>>();

                    db.Database.EnsureCreated();
                }
            });
        }
    }
}
