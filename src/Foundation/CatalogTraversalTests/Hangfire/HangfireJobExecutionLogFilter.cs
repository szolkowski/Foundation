using Hangfire.States;
using Hangfire.Storage;
using Microsoft.Extensions.Logging;

namespace Foundation.CatalogTraversalTests.Hangfire.HangfireJobs;

public class HangfireJobExecutionLogFilter : IElectStateFilter, IApplyStateFilter
{
    private readonly ILogger<HangfireJobExecutionLogFilter> _logger;

    public HangfireJobExecutionLogFilter(ILogger<HangfireJobExecutionLogFilter> logger)
    {
        _logger = logger;
    }

    public void OnStateElection(ElectStateContext context)
    {
        var failedState = context.CandidateState as FailedState;
        if (failedState != null)
        {
            _logger.LogError(
                failedState.Exception,
                "Job {JobId} ({JobType}) failed: {ErrorMessage}",
                context.BackgroundJob.Id,
                context.BackgroundJob.Job.Type.Name,
                failedState.Exception.Message);
        }
    }

    public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
        if (context.NewState is SucceededState)
        {
            _logger.LogInformation(
                "Job {JobId} ({JobType}) completed successfully",
                context.BackgroundJob.Id,
                context.BackgroundJob.Job.Type.Name);
        }
    }

    public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
    }
}