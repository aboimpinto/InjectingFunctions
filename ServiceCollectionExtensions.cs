using Microsoft.Extensions.DependencyInjection;

namespace InjectingFunctions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterDelegate<TSource, TDelegate>(
        this IServiceCollection serviceCollection,
        Func<TSource, TDelegate> getDelegateFromSource) 
            where TDelegate : Delegate 
    {
        return serviceCollection.AddSingleton(provider =>
            getDelegateFromSource(provider.GetService<TSource>()));
    }
}