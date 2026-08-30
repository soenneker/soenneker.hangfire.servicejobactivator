[![](https://img.shields.io/nuget/v/Soenneker.Hangfire.ServiceJobActivator.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ServiceJobActivator/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.servicejobactivator/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.servicejobactivator/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.servicejobactivator/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.hangfire.servicejobactivator/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Hangfire.ServiceJobActivator.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ServiceJobActivator/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.servicejobactivator/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.servicejobactivator/actions/workflows/codeql.yml)

# Soenneker.Hangfire.ServiceJobActivator

Creates each Hangfire job through Microsoft dependency injection in its own service scope. Constructor-injected scoped dependencies are reused within one job and disposed when that job activation scope ends.

## Installation

```bash
dotnet add package Soenneker.Hangfire.ServiceJobActivator
```

## Configure Hangfire

```csharp
using Hangfire;
using Soenneker.Hangfire.ServiceJobActivator.Registrars;

builder.Services.AddScoped<ImportJob>();
builder.Services.AddScoped<IImportRepository, ImportRepository>();

builder.Services.AddHangfire((serviceProvider, configuration) =>
{
    configuration
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .AddServiceJobActivator(serviceProvider);
});
```

## Define and enqueue a job

```csharp
public sealed class ImportJob(IImportRepository repository)
{
    public Task Run(Guid importId, CancellationToken cancellationToken) =>
        repository.RunImport(importId, cancellationToken);
}

string jobId = BackgroundJob.Enqueue<ImportJob>(job =>
    job.Run(importId, CancellationToken.None));
```

The activator creates one `IServiceScope` for the job, resolves the job type as a required service, and disposes the scope after execution. The job type and all of its constructor dependencies must therefore be registered. A missing registration fails immediately with `InvalidOperationException` instead of producing a null job instance.

Keep singleton dependencies free of scoped-service captures. Services that require asynchronous-only disposal are not suitable for this activator because Hangfire's activation scope is disposed synchronously.
