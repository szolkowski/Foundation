using Hangfire;
using Hangfire.Server;
using System.Threading;

namespace Foundation.CatalogTraversalTests.Hangfire.HangfireJobs;

[AutomaticRetry(Attempts = 3, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
public class HangfireRetryableCatalogExportJob
{
    public void Execute(PerformContext context, CancellationToken cancellationToken)
    {
        // Job implementation
    }
}