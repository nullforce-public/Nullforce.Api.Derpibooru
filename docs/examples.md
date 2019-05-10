# Usage Examples

```csharp
using Flurl;
using Flurl.Http;
using Nullforce.Api.Derpibooru;
using Nullforce.Api.Derpibooru.JsonModels;

...

var uri = "https://derpibooru.org/search.json";
uri = uri.SetQueryParam("q", "fluttershy");

var searchResult = await uri.GetJsonAsync<SearchRootJson>();
```

## Getting Images from the Front Page of Derpibooru

```csharp
var derpiClient = new DerpiClient();
var searchResult = await derpiClient
    .Search()
    .Uri
    .GetJsonAsync<SearchRootJson>();

foreach (var image in searchResult.Search)
    Console.WriteLine($"{image.Id} - score: {image.Score} - {image.Tags}");
```

## Search Posts by Tag

```csharp
var derpiClient = new DerpiClient();
var searchResult = await derpiClient
    .Search()
    .WithQuery("rarity AND twilight sparkle")
    .Uri
    .GetJsonAsync<SearchRootJson>();

foreach (var image in searchResult.Search)
    Console.WriteLine(image.Uri);
```

### Getting random posts

```csharp
var derpiClient = new DerpiClient();
var searchResult = await derpiClient
    .Search()
    .SortBy(DerpiSortOptions.Random)
    .Uri
    .GetJsonAsync<SearchRootJson>();

foreach (var image in searchResult.Search)
    Console.WriteLine(image.Uri);
```

### Getting top posts
```csharp
var derpiClient = new DerpiClient();
var searchResult = await derpiClient
    .Search()
    .SortBy(DerpiSortOptions.Score)
    .Uri
    .GetJsonAsync<SearchRootJson>();
```
