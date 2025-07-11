using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Tests.Base;

public class BackendFactory : WebApplicationFactory<Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		Env.SetAsTesting();

		builder.UseTestServer();

		builder.ConfigureAppConfiguration(config =>
		{
			var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Testing.json");

			var configuration = new ConfigurationBuilder()
				.AddJsonFile(configPath)
				.Build();

			config.AddConfiguration(configuration);
		});
	}

    public BackendHttpClient GetClient()
    {
        return new(CreateClient());
    }
}
