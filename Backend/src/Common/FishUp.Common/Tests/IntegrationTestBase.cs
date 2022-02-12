using FishUp.Common.DTO;
using FishUp.Common.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace FishUp.Common.Tests
{
    public abstract class IntegrationTestBase<TContext, TStartup> 
        where TContext: DbContext
        where TStartup: class
    {
        public TestServer TestServer { get; set; }
        public HttpClient HttpClient { get; set; }
        public TContext DbContext { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        public IntegrationTestBase()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.Test.json", optional: true)
                .AddEnvironmentVariables();

            TestServer = new TestServer(new WebHostBuilder()
                .UseStartup<TStartup>());
            Configuration = builder.Build();
            ServiceProvider = TestServer.Services.GetService<IServiceProvider>();
            DbContext = ServiceProvider.GetService<TContext>();
            
            HttpClient = TestServer.CreateClient();
        }

        public string GetAccessToken(UserDTO userDTO)
        {
            var key = Configuration["Jwt:Key"];
            var issuer = Configuration["Jwt:Issuer"];
            var audience = Configuration["Jwt:Audience"];
            var expirationTime = Configuration["Jwt:ExpirationTime"];
            var jwtHandler = ServiceProvider.GetService<IJwtHandler>();
            
            return jwtHandler.BuildToken(key, audience, issuer, Convert.ToInt32(expirationTime), userDTO);
        }
    }
}
