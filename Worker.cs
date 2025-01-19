using Microsoft.Extensions.Hosting;

namespace InjectingFunctions;

public class Worker : BackgroundService
{
    private readonly IEnumerable<IStrategy> _strategies;

    public Worker(IEnumerable<IStrategy> strategies)
    {
        this._strategies = strategies;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {

        var objectRecords = new[] 
        {
            new ObjectRecord(Guid.NewGuid(), "Paulo", ObjectType.Client),
            new ObjectRecord(Guid.NewGuid(), "Isabel", ObjectType.Supplier),
        }
        .ToList();

        objectRecords.ForEach(record => 
        {
            var strategy = this._strategies
                .Single(strategy => strategy.CanHandle(record));

            Console.WriteLine(record.Process(strategy.Handle));
        });

        return Task.CompletedTask;
    }
}

public static class HandlerExtentions
{
    public delegate string ObjectHandler(string input);

    public static string ProcessObject(this string input, ObjectHandler objectHandler) => 
        objectHandler(input);
}