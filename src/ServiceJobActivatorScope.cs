using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

public class ServiceJobActivatorScope : JobActivatorScope
{
    private readonly IServiceScope _serviceScope;

    public ServiceJobActivatorScope(IServiceScope serviceScope)
    {
        if (serviceScope == null)
            throw new ArgumentNullException(nameof(serviceScope));

        _serviceScope = serviceScope;
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