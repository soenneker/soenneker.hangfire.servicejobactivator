using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator.Registrars;

/// <summary>
/// Overrides the default Hangfire activator and resolves services through .NET's default DI provider
/// </summary>
public static class ServiceJobActivatorRegistrar
{
    /// <summary>
    /// Overrides the default Hangfire activator and resolves services through .NET's default DI provider
    /// </summary>
    /// <param name="config">Config for the add service job activator operation.</param>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The resulting global Configuration.</returns>
    public static IGlobalConfiguration AddServiceJobActivator(this IGlobalConfiguration config, IServiceProvider services)
    {
        config.UseActivator(new ServiceJobActivator(services.GetService<IServiceScopeFactory>()!));

        return config;
    }
}
