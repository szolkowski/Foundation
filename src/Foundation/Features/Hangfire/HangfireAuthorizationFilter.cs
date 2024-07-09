using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Foundation.Features.Hangfire;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        return EPiServer.Security.PrincipalInfo.CurrentPrincipal.IsInRole("CmsAdmins");
    }
}