using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator.Extensions;

public static class ServiceJobActivatorExtension
{
    /// <summary>
    /// Overrides the default Hangfire activator and resolves services through .NET's default DI provider
    /// </summary>
    public static void AddServiceJobActivator(this IGlobalConfiguration config, IServiceProvider serviceProvider)
    {
        config.UseActivator(new ServiceJobActivator(serviceProvider.GetService<IServiceScopeFactory>()!));
    }
}