using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

public sealed class ServiceJobActivatorScope : JobActivatorScope
{
    private readonly IServiceScope _serviceScope;

    public ServiceJobActivatorScope(IServiceScope serviceScope)
    {
        _serviceScope = serviceScope ?? throw new ArgumentNullException(nameof(serviceScope));
    }

    public override object Resolve(Type type)
    {
        return _serviceScope.ServiceProvider.GetService(type)!;
    }

    public override void DisposeScope()
    {
        _serviceScope.Dispose();
        base.DisposeScope();
    }
}