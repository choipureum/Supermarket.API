using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Supermarket.API.Integration.Tests
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .Build();

            WebHostBuilder webHostBuilder = new WebHostBuilder();
            webHostBuilder.ConfigureServices(s => s.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("supermarket-api-in-memory-test")));
            webHostBuilder.UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);

            Client = server.CreateClient();
        }
        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
