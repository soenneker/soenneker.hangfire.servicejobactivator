[![](https://img.shields.io/nuget/v/Soenneker.Hangfire.ServiceJobActivator.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ServiceJobActivator/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.servicejobactivator/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.servicejobactivator/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Hangfire.ServiceJobActivator.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ServiceJobActivator/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.servicejobactivator/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.servicejobactivator/actions/workflows/codeql.yml)

# Soenneker.Hangfire.ServiceJobActivator

Overrides the default Hangfire activator and resolves services through .NET's default DI provider.

## Install

```bash
dotnet add package Soenneker.Hangfire.ServiceJobActivator
```

## Quick start

```csharp
using Soenneker.Hangfire.ServiceJobActivator.Registrars;

IGlobalConfiguration config = /* obtain from your application */;
var result = config.AddServiceJobActivator(/* supply services */ default!);
```

Overrides the default Hangfire activator and resolves services through .NET's default DI provider.

## What you get

- `ServiceJobActivatorRegistrar` — Overrides the default Hangfire activator and resolves services through .NET's default DI provider.
- `ServiceJobActivator` — Overrides the default Hangfire activator and resolves services through .NET's default DI provider.
- `ServiceJobActivatorScope` — Represents the service job activator scope.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ServiceJobActivatorRegistrar.AddServiceJobActivator(config, services)` | Overrides the default Hangfire activator and resolves services through .NET's default DI provider. | The resulting global Configuration. |
| `ServiceJobActivator.BeginScope(context)` | Executes the begin scope operation. | The result of the operation. |
| `ServiceJobActivatorScope.Resolve(type)` | Executes the resolve operation. | The result of the operation. |
