using Soenneker.Resend.ClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Resend.ClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ResendClientUtilTests : HostedUnitTest
{
    private readonly IResendClientUtil _kiotaclient;

    public ResendClientUtilTests(Host host) : base(host)
    {
        _kiotaclient = Resolve<IResendClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
