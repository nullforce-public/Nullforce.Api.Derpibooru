using Nullforce.Api.Derpibooru.JsonModels;

namespace Nullforce.Api.Derpibooru.Tests;

public class SearchTests
{
    private readonly DerpiClient _client = new();

    public SearchTests()
    {
        // Do this in Startup. All calls to the URI will use the same HttpClient instance.
        FlurlHttp.ConfigureClient("https://derpibooru.org/api/v1/json", cli => cli
            .WithHeaders(new
            {
                Accept = "application/json",
                User_Agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36"
            }));
    }

    [Fact]
    [Trait(TestConstants.Category, TestConstants.DerpibooruCall)]
    public async Task SearchRawUri()
    {
        var uri = "https://derpibooru.org/api/v1/json/search/images";
        uri = uri.SetQueryParam("q", "fluttershy");

        var searchResult = await uri.GetJsonAsync<ImageSearchRootJson>();

        searchResult.Should().NotBeNull();
    }

    [Fact]
    [Trait(TestConstants.Category, TestConstants.DerpibooruCall)]
    public async Task Search_WithDefaultExample_ReturnsResults()
    {
        var searchResult = await _client
            .Search()
            .Uri
            .GetJsonAsync<ImageSearchRootJson>();

        searchResult.Should().NotBeNull();
        searchResult.Images.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    [Trait(TestConstants.Category, TestConstants.DerpibooruCall)]
    public async Task Search_ByTag_ReturnsResults()
    {
        const string Rarity = "rarity";
        const string TwilightSparkle = "twilight sparkle";
        var searchResult = await _client
            .Search()
            .WithQuery($"{Rarity} AND {TwilightSparkle}")
            .Uri
            .GetJsonAsync<ImageSearchRootJson>();

        searchResult.Should().NotBeNull();
        searchResult.Images.Length.Should().BeGreaterThan(0);
        searchResult.Images[0].Tags.Should().Contain(new string[] { Rarity, TwilightSparkle });
    }

    [Fact]
    [Trait(TestConstants.Category, TestConstants.DerpibooruCall)]
    public async Task Search_ByRandom_ReturnsResults()
    {
        var searchResult = await _client
            .Search()
            .SortBy("random")
            .Uri
            .GetJsonAsync<ImageSearchRootJson>();

        var searchResult2 = await _client
            .Search()
            .SortBy("random")
            .Uri
            .GetJsonAsync<ImageSearchRootJson>();

        searchResult.Should().NotBeNull();
        searchResult.Images.Length.Should().BeGreaterThan(0);
        searchResult2.Should().NotBeNull();
        searchResult2.Images.Length.Should().BeGreaterThan(0);
        searchResult.Should().NotBe(searchResult2);
        searchResult.Images[0].Id.Should().NotBe(searchResult2.Images[0].Id);
    }

    [Fact]
    public void Search_WithApiKey_HasKeyParam()
    {
        const string ApiKey = "apikey";
        var derpiClient = new DerpiClient(ApiKey);

        var uri = derpiClient.Search().Uri;

        uri.Should().Contain($"key={ApiKey}");
    }

    [Fact]
    public void Search_WithoutApiKey_HasNoKeyParam()
    {
        var derpiClient = new DerpiClient();

        var uri = derpiClient.Search().Uri;

        uri.Should().NotContain("key=");
    }
}
