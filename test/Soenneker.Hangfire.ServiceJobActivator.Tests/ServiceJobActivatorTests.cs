using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Hangfire.ServiceJobActivator.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ServiceJobActivatorTests : HostedUnitTest
{
    public ServiceJobActivatorTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {
    }

    [Test]
    public async Task Resolve_should_fail_for_an_unregistered_job()
    {
        using ServiceProvider provider = new ServiceCollection().BuildServiceProvider();
        var scope = new ServiceJobActivatorScope(provider.CreateScope());
        Action act = () => scope.Resolve(typeof(UnregisteredJob));

        await Assert.That(act).Throws<InvalidOperationException>();

        scope.DisposeScope();
    }

    private sealed class UnregisteredJob
    {
    }
}
