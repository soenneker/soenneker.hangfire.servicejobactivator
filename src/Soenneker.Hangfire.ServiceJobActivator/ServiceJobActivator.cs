using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

/// <summary>
/// Creates a dependency-injection scope for each activated Hangfire job.
/// </summary>
public sealed class ServiceJobActivator : JobActivator
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServiceJobActivator(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    }

    /// <summary>
    /// Creates the dependency-injection scope used to resolve one Hangfire job.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>An activator scope that owns the created service scope.</returns>
    public override JobActivatorScope BeginScope(JobActivatorContext context)
    {
        return new ServiceJobActivatorScope(_serviceScopeFactory.CreateScope());
    }
}
