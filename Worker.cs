using InjectingFunctions.ModuleOne;
using Microsoft.Extensions.Hosting;

namespace InjectingFunctions;

public class Worker : BackgroundService
{
    public Worker(IEnumerable<StringHandler> processorOneDelegates)
    {
        // var xxx = processorOneDelegate("AAA");

        foreach (var processor in processorOneDelegates)
        {
            Console.WriteLine(processor("AAA"));
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {


        // Console.WriteLine("AAA".ProcessObject());

        return Task.CompletedTask;
    }
}

public static class HandlerExtentions
{
    public delegate string ObjectHandler(string input);

    public static string ProcessObject(this string input, ObjectHandler objectHandler) => 
        objectHandler(input);
}