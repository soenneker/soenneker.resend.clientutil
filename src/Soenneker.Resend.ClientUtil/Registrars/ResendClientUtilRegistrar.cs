using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Resend.Client.Registrars;
using Soenneker.Resend.ClientUtil.Abstract;

namespace Soenneker.Resend.ClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Resend API client.
/// </summary>
public static class ResendClientUtilRegistrar
{
    /// <summary>
    /// Adds the Resend API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddResendClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddResendHttpClientAsSingleton()
                .TryAddSingleton<IResendClientUtil, ResendClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Resend API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddResendClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddResendHttpClientAsSingleton()
                .TryAddScoped<IResendClientUtil, ResendClientUtil>();

        return services;
    }
}
