[![](https://img.shields.io/nuget/v/soenneker.resend.clientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.resend.clientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.resend.clientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.resend.clientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.resend.clientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.resend.clientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.resend.clientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.resend.clientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Resend.ClientUtil

Provides a lazily initialized Resend client for email, domains, contacts, audiences, broadcasts, templates, topics, events, logs, webhooks, and API keys.

## Installation

```bash
dotnet add package Soenneker.Resend.ClientUtil
```

## Configuration

```json
{
  "Resend": {
    "ApiKey": "re_xxxxxxxxx"
  }
}
```

## Usage

```csharp
using Soenneker.Resend.ClientUtil.Abstract;
using Soenneker.Resend.ClientUtil.Registrars;

services.AddResendClientUtilAsSingleton();

public sealed class ResendDomainReader
{
    private readonly IResendClientUtil _resend;

    public ResendDomainReader(IResendClientUtil resend)
    {
        _resend = resend;
    }

    public async Task GetDomains(CancellationToken cancellationToken)
    {
        var client = await _resend.Get(cancellationToken);
        var domains = await client.Domains.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

The underlying provider sends the bearer API key and the `User-Agent` header required by Resend. Use `AddResendClientUtilAsScoped()` when each scope should have its own lazily initialized API client; both registrations reuse the singleton authenticated HTTP client provider.
