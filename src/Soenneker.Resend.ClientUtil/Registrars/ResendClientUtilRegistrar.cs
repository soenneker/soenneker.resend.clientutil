using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Resend.Client.Registrars;
using Soenneker.Resend.ClientUtil.Abstract;

namespace Soenneker.Resend.ClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class ResendClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ResendClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddResendClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddResendHttpClientAsSingleton()
                .TryAddSingleton<IResendClientUtil, ResendClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ResendClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddResendClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddResendHttpClientAsSingleton()
                .TryAddScoped<IResendClientUtil, ResendClientUtil>();

        return services;
    }
}
