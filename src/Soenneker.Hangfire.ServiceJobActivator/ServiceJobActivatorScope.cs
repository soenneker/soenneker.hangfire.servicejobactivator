using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

/// <summary>
/// Resolves one Hangfire job from an owned dependency-injection scope.
/// </summary>
public sealed class ServiceJobActivatorScope : JobActivatorScope
{
    private readonly IServiceScope _serviceScope;

    public ServiceJobActivatorScope(IServiceScope serviceScope)
    {
        _serviceScope = serviceScope ?? throw new ArgumentNullException(nameof(serviceScope));
    }

    /// <summary>
    /// Resolves a required job or dependency from the job scope.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The resolved service.</returns>
    public override object Resolve(Type type)
    {
        return _serviceScope.ServiceProvider.GetRequiredService(type);
    }

    /// <summary>
    /// Disposes the dependency-injection scope and its scoped services.
    /// </summary>
    public override void DisposeScope()
    {
        _serviceScope.Dispose();
        base.DisposeScope();
    }
}
