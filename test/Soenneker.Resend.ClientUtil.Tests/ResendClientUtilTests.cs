using Soenneker.Resend.ClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Resend.ClientUtil.Tests;

[Collection("Collection")]
public sealed class ResendClientUtilTests : FixturedUnitTest
{
    private readonly IResendClientUtil _kiotaclient;

    public ResendClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _kiotaclient = Resolve<IResendClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
