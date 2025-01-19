using InjectingFunctions.ModuleOne.StrategyFunctions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InjectingFunctions.ModuleOne;

public static class ModuleOneHostBuilder
{
    public static IHostBuilder RegisterModuleOne(this IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) => 
        {  
            services.AddTransient<IStrategy, ModuleOneStrategy>();

            services.AddSingleton<ModuleOneProcessor>();
            services.RegisterDelegate<ModuleOneProcessor, StringHandler>(x => x.ProcessorOne);
        });

        return builder;
    }
}
