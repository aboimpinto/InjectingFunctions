// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using InjectingFunctions.ModuleOne;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InjectingFunctions;


public class Program
{
    public static void Main()=> 
        CreateHostBuilder()
            .Build()
            .Run();
    
    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .UseSystemd()
            .ConfigureServices((hostedContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
            .RegisterModuleOne()
            .RegisterModuleTwo();
}

public record ObjectRecord(Guid Id, string Name, ObjectType ObjectType)
{
    public string Process(Func<ObjectRecord, string> processor)
    {
        return $"{Name} ({processor(this)})";
    }
}

public enum ObjectType 
{
    Client,
    Supplier
}