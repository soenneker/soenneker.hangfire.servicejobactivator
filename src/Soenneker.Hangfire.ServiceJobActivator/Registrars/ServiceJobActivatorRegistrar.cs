using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator.Registrars;

/// <summary>
/// Configures Hangfire to create jobs through the application's dependency-injection provider.
/// </summary>
public static class ServiceJobActivatorRegistrar
{
    /// <summary>
    /// Replaces Hangfire's job activator with one that creates a dependency-injection scope per job.
    /// </summary>
    /// <param name="config">The Hangfire global configuration.</param>
    /// <param name="services">The application service provider used to create job scopes.</param>
    /// <returns>The same global configuration.</returns>
    public static IGlobalConfiguration AddServiceJobActivator(this IGlobalConfiguration config, IServiceProvider services)
    {
        config.UseActivator(new ServiceJobActivator(services.GetRequiredService<IServiceScopeFactory>()));

        return config;
    }
}
