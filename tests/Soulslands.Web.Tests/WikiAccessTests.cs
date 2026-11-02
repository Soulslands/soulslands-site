using System.Security.Claims;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Tests;

public class WikiAccessTests
{
    private static ClaimsPrincipal UserWithRoles(params string[] roles)
    {
        // The shape of the studio's id token: "role" claims, read as roles by the sign-in cookie.
        var claims = roles.Select(r => new Claim(StudioSignIn.RoleClaim, r)).Append(new Claim(StudioSignIn.NameClaim, "tester"));
        return new ClaimsPrincipal(new ClaimsIdentity(claims, "Test", StudioSignIn.NameClaim, StudioSignIn.RoleClaim));
    }

    [Theory]
    [InlineData(Roles.Admin)]
    [InlineData(Roles.Moderatore)]
    [InlineData(Roles.Agente)]
    public void StaffCanReadStaffPages(string role)
    {
        Assert.True(WikiAccess.CanRead(UserWithRoles(role), WikiVisibility.Staff));
    }

    [Fact]
    public void PlayerCannotReadStaffPages()
    {
        Assert.False(WikiAccess.CanRead(UserWithRoles(), WikiVisibility.Staff));
        Assert.False(WikiAccess.CanRead(new ClaimsPrincipal(), WikiVisibility.Staff));
    }

    [Fact]
    public void EveryoneCanReadPublicPages()
    {
        Assert.True(WikiAccess.CanRead(new ClaimsPrincipal(), WikiVisibility.Pubblica));
    }

    [Fact]
    public void OnlyAdminsAndModeratorsCanEdit()
    {
        Assert.True(WikiAccess.CanEdit(UserWithRoles(Roles.Admin)));
        Assert.True(WikiAccess.CanEdit(UserWithRoles(Roles.Moderatore)));
        Assert.False(WikiAccess.CanEdit(UserWithRoles(Roles.Agente)));
        Assert.False(WikiAccess.CanEdit(UserWithRoles()));
    }

    [Theory]
    [InlineData("razze-e-classi", true)]
    [InlineData("skill100", true)]
    [InlineData("Razze", false)]
    [InlineData("razze--classi", false)]
    [InlineData("-razze", false)]
    [InlineData("razze e classi", false)]
    [InlineData("modifica", false)]
    [InlineData("", false)]
    public void ValidatesSlugs(string slug, bool expected)
    {
        Assert.Equal(expected, WikiAccess.IsValidSlug(slug));
    }
}
