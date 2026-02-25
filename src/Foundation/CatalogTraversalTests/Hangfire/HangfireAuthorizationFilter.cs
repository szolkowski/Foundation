using Hangfire.Dashboard;

namespace Foundation.CatalogTraversalTests.Hangfire;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        
        // In production, implement proper authorization
        // For example, check if user is in admin role
        return httpContext.User.IsInRole("WebAdmins") || 
               httpContext.User.IsInRole("Administrators");
    }
}