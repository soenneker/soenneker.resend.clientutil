using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Resend.ClientUtil.Abstract;
using Soenneker.Kiota.BearerAuthenticationProvider;
using Soenneker.Resend.Client.Abstract;
using Soenneker.Resend.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Resend.ClientUtil;

///<inheritdoc cref="IResendClientUtil"/>
public sealed class ResendClientUtil : IResendClientUtil
{
    private readonly AsyncSingleton<ResendOpenApiClient> _client;

    public ResendClientUtil(IResendHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ResendOpenApiClient>(async (token, _) =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Resend:ApiKey");

            var requestAdapter = new HttpClientRequestAdapter(new BearerAuthenticationProvider(apiKey), httpClient: httpClient);

            return new ResendOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ResendOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
