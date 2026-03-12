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
    private readonly IResendHttpClient _httpClientUtil;
    private readonly string _apiKey;

    public ResendClientUtil(IResendHttpClient httpClientUtil, IConfiguration configuration)
    {
        _httpClientUtil = httpClientUtil;
        _apiKey = configuration.GetValueStrict<string>("Resend:ApiKey");
        _client = new AsyncSingleton<ResendOpenApiClient>(CreateClient);
    }

    private async ValueTask<ResendOpenApiClient> CreateClient(CancellationToken token)
    {
        HttpClient httpClient = await _httpClientUtil.Get(token)
                                                     .NoSync();

        var requestAdapter = new HttpClientRequestAdapter(new BearerAuthenticationProvider(_apiKey), httpClient: httpClient);

        return new ResendOpenApiClient(requestAdapter);
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