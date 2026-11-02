using System.Net;
using Microsoft.AspNetCore.Hosting;

namespace Soulslands.Web.Tests;

public class DeploymentTests(SiteFactory factory) : IClassFixture<SiteFactory>
{
    [Fact]
    public async Task HealthEndpointReportsHealthy()
    {
        var response = await factory.CreateClient().GetAsync("/api/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Healthy", await response.Content.ReadAsStringAsync());
    }

    // Production (docker-compose.yml) sets AllowedHosts to SITE_DOMAIN plus localhost, which
    // the Docker HEALTHCHECK uses; home mode keeps "*".
    [Fact]
    public async Task AllowedHostsRejectsAnyOtherHost()
    {
        var site = factory.WithWebHostBuilder(b => b.UseSetting("AllowedHosts", "soulslands.example"));

        async Task<HttpStatusCode> Get(string host)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/health");
            request.Headers.Host = host;
            return (await site.CreateClient().SendAsync(request)).StatusCode;
        }

        Assert.Equal(HttpStatusCode.OK, await Get("soulslands.example"));
        Assert.Equal(HttpStatusCode.BadRequest, await Get("altro.example"));
        Assert.Equal(HttpStatusCode.BadRequest, await Get("localhost"));
    }

    [Fact]
    public async Task AllowedHostsWithLocalhostKeepsTheHealthcheckWorking()
    {
        var site = factory.WithWebHostBuilder(b => b.UseSetting("AllowedHosts", "soulslands.example;localhost"));

        using var request = new HttpRequestMessage(HttpMethod.Get, "/api/health");
        request.Headers.Host = "localhost:8080";
        Assert.Equal(HttpStatusCode.OK, (await site.CreateClient().SendAsync(request)).StatusCode);
    }
}
