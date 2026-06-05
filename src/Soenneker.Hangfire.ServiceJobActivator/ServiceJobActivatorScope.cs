using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

/// <summary>
/// Represents the service job activator scope.
/// </summary>
public sealed class ServiceJobActivatorScope : JobActivatorScope
{
    private readonly IServiceScope _serviceScope;

    public ServiceJobActivatorScope(IServiceScope serviceScope)
    {
        _serviceScope = serviceScope ?? throw new ArgumentNullException(nameof(serviceScope));
    }

    /// <summary>
    /// Executes the resolve operation.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The result of the operation.</returns>
    public override object Resolve(Type type)
    {
        return _serviceScope.ServiceProvider.GetService(type)!;
    }

    /// <summary>
    /// Disposes scope.
    /// </summary>
    public override void DisposeScope()
    {
        _serviceScope.Dispose();
        base.DisposeScope();
    }
}