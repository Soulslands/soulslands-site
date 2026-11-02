using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Soulslands.Web.Data;
using Soulslands.Web.Services.Servers;

namespace Soulslands.Web.Tests;

public class ServerStatusTests(SiteFactory factory) : IClassFixture<SiteFactory>
{
    private async Task<(string Name, string Key)> AddServerAsync()
    {
        var name = $"Test-{Guid.NewGuid():N}"[..20];
        var key = ServerStatus.NewApiKey();
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.GameServers.Add(new GameServer { Name = name, Address = "play.soulslands.test:7777", ApiKeyHash = ServerStatus.HashKey(key) });
        await db.SaveChangesAsync();
        return (name, key);
    }

    private static HttpRequestMessage Heartbeat(string key, int players) =>
        new(HttpMethod.Post, "/api/servers/heartbeat")
        {
            Headers = { Authorization = new AuthenticationHeaderValue("Server", key) },
            Content = JsonContent.Create(new HeartbeatRequest(players, 500, "0.1.0")),
        };

    [Fact]
    public async Task ServerIsOfflineUntilItReportsIn()
    {
        var (name, key) = await AddServerAsync();
        var client = factory.CreateClient();

        var before = (await client.GetFromJsonAsync<List<ServerInfo>>("/api/servers"))!.Single(s => s.Name == name);
        Assert.False(before.Online);

        Assert.Equal(HttpStatusCode.NoContent, (await client.SendAsync(Heartbeat(key, 42))).StatusCode);

        var after = (await client.GetFromJsonAsync<List<ServerInfo>>("/api/servers"))!.Single(s => s.Name == name);
        Assert.True(after.Online);
        Assert.Equal(42, after.PlayersOnline);
        Assert.Contains(name, await client.GetStringAsync("/Stato"));
    }

    [Fact]
    public async Task HeartbeatNeedsAValidKey()
    {
        var client = factory.CreateClient();
        Assert.Equal(HttpStatusCode.Unauthorized, (await client.SendAsync(Heartbeat("ssk_wrong", 1))).StatusCode);

        var unsigned = await client.PostAsJsonAsync("/api/servers/heartbeat", new HeartbeatRequest(1, 1, null));
        Assert.Equal(HttpStatusCode.Unauthorized, unsigned.StatusCode);
    }
}

public partial class ServerOwnerTests(SiteFactory factory) : IClassFixture<SiteFactory>
{
    [System.Text.RegularExpressions.GeneratedRegex("name=\"__RequestVerificationToken\" type=\"hidden\" value=\"([^\"]+)\"")]
    private static partial System.Text.RegularExpressions.Regex TokenPattern();

    // A studio account (its "sub"), with no role and no purchase: hosting a server needs neither.
    private HttpClient SignedIn(string? subject = null)
    {
        var client = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        client.DefaultRequestHeaders.Add(TestAuthHandler.Header, "Giocatore");
        client.DefaultRequestHeaders.Add(TestAuthHandler.UserHeader, subject ?? Guid.NewGuid().ToString());
        return client;
    }

    private static async Task<HttpResponseMessage> PostAsync(HttpClient client, string path, Dictionary<string, string> fields)
    {
        var html = await client.GetStringAsync("/Server");
        fields["__RequestVerificationToken"] = TokenPattern().Match(html).Groups[1].Value;
        return await client.PostAsync(path, new FormUrlEncodedContent(fields));
    }

    [Fact]
    public async Task AnyAccountCanRegisterAServerAndOnlyItsOwnerManagesIt()
    {
        var owner = SignedIn();
        var name = $"Mondo-{Guid.NewGuid():N}"[..14];
        var created = await PostAsync(owner, "/Server", new() { ["Name"] = name, ["Address"] = "play.example.test:7777" });
        Assert.Equal(HttpStatusCode.Redirect, created.StatusCode);

        var page = await owner.GetStringAsync("/Server");
        Assert.Contains(name, page);
        Assert.Matches("ssk_[0-9a-f]{48}", page);

        using (var scope = factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var id = db.GameServers.Single(s => s.Name == name).Id;

            var stranger = SignedIn();
            Assert.DoesNotContain(name, await stranger.GetStringAsync("/Server"));
            await PostAsync(stranger, $"/Server?handler=Delete&id={id}", []);
            Assert.True(db.GameServers.Any(s => s.Id == id));
        }
    }

    [Fact]
    public async Task OwnerDeletesItsServerKeyedByTheStudioId()
    {
        var subject = Guid.NewGuid().ToString();
        var owner = SignedIn(subject);
        var name = $"Mio-{Guid.NewGuid():N}"[..12];
        await PostAsync(owner, "/Server", new() { ["Name"] = name, ["Address"] = "play.example.test:7777" });

        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var server = db.GameServers.Single(s => s.Name == name);
        Assert.Equal(subject, server.OwnerId);

        // Same account, signed in again later: the studio id is the key, not a session.
        await PostAsync(SignedIn(subject), $"/Server?handler=Delete&id={server.Id}", []);
        Assert.False(db.GameServers.Any(s => s.Id == server.Id));
    }

    [Fact]
    public async Task AtMostFiveServersPerAccount()
    {
        var owner = SignedIn();
        for (var i = 0; i < 6; i++)
        {
            await PostAsync(owner, "/Server", new() { ["Name"] = $"Limite-{i}", ["Address"] = "play.example.test:7777" });
        }

        var page = await owner.GetStringAsync("/Server");
        Assert.Equal(5, Regex.Matches(page, "Limite-[0-9]").Select(m => m.Value).Distinct().Count());
        Assert.Contains("al massimo 5 server", page);
    }

    [Fact]
    public async Task AddressMustBeHostAndPort()
    {
        var owner = SignedIn();
        var name = $"Bad-{Guid.NewGuid():N}"[..12];
        var response = await PostAsync(owner, "/Server", new() { ["Name"] = name, ["Address"] = "not an address" });
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("host:porta", System.Net.WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task RegisteringAServerNeedsAnAccount()
    {
        var response = await factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false }).GetAsync("/Server");
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }
}
