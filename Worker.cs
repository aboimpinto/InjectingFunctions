
using System.IO.Compression;
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

        objectRecords
            .SelectMany(record => this._strategies
                .Where(strategy => strategy.CanHandle(record))
                .Select(strategy => new { Record = record, Strategy = strategy }))
            .ToList()
            .ForEach(x => Console.WriteLine(x.Strategy.Handle(x.Record)));



        return Task.CompletedTask;
    }
}

public static class HandlerExtentions
{
    public delegate string ObjectHandler(string input);

    public static string ProcessObject(this string input, ObjectHandler objectHandler) => 
        objectHandler(input);
}