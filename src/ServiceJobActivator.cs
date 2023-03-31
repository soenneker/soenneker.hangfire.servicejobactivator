using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Hangfire.ServiceJobActivator;

public class ServiceJobActivator : JobActivator
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServiceJobActivator(IServiceScopeFactory serviceScopeFactory)
    {
        if (serviceScopeFactory == null)
            throw new ArgumentNullException(nameof(serviceScopeFactory));

        _serviceScopeFactory = serviceScopeFactory;
    }

    public override JobActivatorScope BeginScope(JobActivatorContext context)
    {
        return new ServiceJobActivatorScope(_serviceScopeFactory.CreateScope());
    }
}