using InjectingFunctions.ModuleTwo.StrategyFunctions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InjectingFunctions.ModuleOne;

public static class ModuleTwoHostBuilder
{
    public static IHostBuilder RegisterModuleTwo(this IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) => 
        {   
            services.AddTransient<IStrategy, ModuleTwoStrategy>();

            services.AddSingleton<ModuleTwoProcessor>();
            services.RegisterDelegate<ModuleTwoProcessor, StringHandler>(x => x.ProcessorTwo);
        });

        return builder;
    }
}
