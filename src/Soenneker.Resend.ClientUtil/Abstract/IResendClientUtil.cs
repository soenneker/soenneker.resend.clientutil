using Soenneker.Resend.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Resend.ClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface IResendClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<ResendOpenApiClient> Get(CancellationToken cancellationToken = default);
}
