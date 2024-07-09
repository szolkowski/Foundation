using EPiServer.Authorization;

namespace Foundation.Features.Hangfire;

[MenuProvider]
public class HangfireMenuProvider: IMenuProvider
{
    public IEnumerable<MenuItem>  GetMenuItems()
    {
        var hangFireMenuItem = new UrlMenuItem("Hangfire", MenuPaths.Global + "/cms" + "/cmsMenuItem",
            "/HangfireCms/index")
        {
            IsAvailable = request => EPiServer.Security.PrincipalInfo.CurrentPrincipal.IsInRole("CmsAdmins"),
            AuthorizationPolicy = CmsPolicyNames.CmsAdmin,
            SortIndex = SortIndex.First + 25
        };

        return new MenuItem[]
        {
            hangFireMenuItem
        };
    }
}