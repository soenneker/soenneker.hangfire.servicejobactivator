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
}