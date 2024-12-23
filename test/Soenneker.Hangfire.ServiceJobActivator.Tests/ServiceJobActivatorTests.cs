using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Hangfire.ServiceJobActivator.Tests;

[Collection("Collection")]
public class ServiceJobActivatorTests : FixturedUnitTest
{
    public ServiceJobActivatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {
    }
}