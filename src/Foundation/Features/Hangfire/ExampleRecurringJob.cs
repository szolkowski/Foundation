using Hangfire.Console;
using Hangfire.Server;
using System.Threading;

namespace Foundation.Features.Hangfire;

public class ExampleRecurringJob
{
    private readonly IContentTypeRepository _contentTypeRepository;


    public ExampleRecurringJob(IContentTypeRepository contentTypeRepository)
    {
        _contentTypeRepository = contentTypeRepository;
    }

    public void Execute(PerformContext context)
    {
        context.WriteLine("Hello, world!");
        Thread.Sleep(TimeSpan.FromSeconds(1));

        context.SetTextColor(ConsoleTextColor.Red);
        context.WriteLine("Error! Just joking :)");
        Thread.Sleep(TimeSpan.FromSeconds(0.2));
        context.ResetTextColor();

        var bar = context.WriteProgressBar();
        foreach (var contentType in _contentTypeRepository.List().WithProgress(bar))
        {
            context.WriteLine(contentType.Name);
            Thread.Sleep(TimeSpan.FromSeconds(0.3));
        }
    }
}
