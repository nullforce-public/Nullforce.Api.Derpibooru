# Nullforce.Api.Derpibooru
A .NET Standard library for consuming derpibooru.org API endpoints.

|||
----------------------|---
**Build**             | [![Build Status](https://github.com/nullforce-public/Nullforce.Api.Derpibooru/workflows/build/badge.svg?branch=main)](https://github.com/nullforce-public/Nullforce.Api.Derpibooru/actions)
**NuGet**             | [![nuget](https://img.shields.io/nuget/v/Nullforce.Api.Derpibooru.svg)](https://www.nuget.org/packages/Nullforce.Api.Derpibooru/)
**NuGet (prerelease)**| [![nuget](https://img.shields.io/nuget/vpre/Nullforce.Api.Derpibooru.svg)](https://www.nuget.org/packages/Nullforce.Api.Derpibooru/)


## Usage Example

An example using [Flurl.Http](https://flurl.dev/):

Install the `Nullforce.Api.Derpibooru` package from NuGet (allow prerelease as needed).

```csharp
using Flurl;
using Flurl.Http;
using Nullforce.Api.Derpibooru;
using Nullforce.Api.Derpibooru.JsonModels;

...

var derpiClient = new DerpiClient();
var searchResult = await derpiClient
    .Search()
    .WithQuery("fluttershy")
    .Page(1)
    .PerPage(50)
    .Uri
    .GetJsonAsync<SearchRootJson>();

foreach (var image in searchResult.Search)
{
    Console.WriteLine($"Downloading {image.Id}...");
    var path = await image.ImageUri
        .DownloadFileAsync(@"c:\downloads");
}
```

[More Examples](docs/examples.md)

## Building / Contributing

TBD


## See Also

If you only want to consume the C# wrapper for the JSON models, you can install
the separate NuGet package:

```shell
dotnet add package Nullforce.Api.Derpibooru.JsonModels
```

[JSON Model Source](https://github.com/nullforce-public/Nullforce.Api.Derpibooru.JsonModels)
