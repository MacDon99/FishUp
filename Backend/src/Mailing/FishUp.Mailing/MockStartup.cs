using FishUp.Mailing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FishUp.Mailing
{
    public class MockStartup : Startup
    {
        public MockStartup(IConfiguration configuration) : base(configuration)
        {

        }

        protected override void AddServicesForEnvironment(IServiceCollection services)
        {
            services.AddDbContext<MailingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IntegrationTestsConnectionString")));
        }

        protected override void SetupConfiguration(string environmentName)
        {
            base.SetupConfiguration("Test");
        }
    }
}
