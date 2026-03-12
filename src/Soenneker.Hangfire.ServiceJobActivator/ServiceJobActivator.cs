using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

/// <summary>
/// Overrides the default Hangfire activator and resolves services through .NET's default DI provider
/// </summary>
public sealed class ServiceJobActivator : JobActivator
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServiceJobActivator(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    }

    public override JobActivatorScope BeginScope(JobActivatorContext context)
    {
        return new ServiceJobActivatorScope(_serviceScopeFactory.CreateScope());
    }
}