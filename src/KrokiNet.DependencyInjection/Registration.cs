using Microsoft.Extensions.DependencyInjection;

namespace KrokiNet.DependencyInjection;

public static class Registration
{
    /// <summary>
    /// Adds the interface IKrokiClient to the IoC container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddKroki(this IServiceCollection services)
    {
        services.AddHttpClient<IKrokiClient, KrokiClient>(client =>
        {
            client.BaseAddress = new Uri("https://kroki.io/");
        });

        return services;
    }

}
