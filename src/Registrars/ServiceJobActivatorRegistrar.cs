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
    public static IGlobalConfiguration AddServiceJobActivator(this IGlobalConfiguration config, IServiceProvider services)
    {
        config.UseActivator(new ServiceJobActivator(services.GetService<IServiceScopeFactory>()!));

        return config;
    }
}