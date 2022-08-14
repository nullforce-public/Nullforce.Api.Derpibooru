using Nullforce.Api.JsonModels.Twibooru;
using Nullforce.Api.UrlBuilder.Twibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Twibooru;

public class TwibooruSearchTests
{
    private readonly TwibooruSearch _search = new("https://twibooru.org/api/v3", string.Empty);

    public TwibooruSearchTests()
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
    public async Task Search_WithDefaults_ReturnsResults()
    {
        var uri = _search.Uri;
        var json = await uri.GetStringAsync();
        var searchResult = JsonSerializer.Deserialize<SearchPostsResponseJson>(json);

        uri.Should().Be("https://twibooru.org/api/v3/search/posts?q=%2A&sf=created_at&sd=desc");

        searchResult.Should().NotBeNull();
        searchResult.JsonExtensionData.Should().BeNull();
        searchResult.Posts.Should().NotBeNull();
        searchResult.Total.Should().BeGreaterThanOrEqualTo(1);
    }

    [Fact]
    public async Task Search_WithId_ReturnsResults()
    {
        var uri = _search
            .WithQuery("id:3")
            .Uri;
        var json = await uri.GetStringAsync();
        var searchResult = JsonSerializer.Deserialize<SearchPostsResponseJson>(json);

        using var _ = new AssertionScope();

        searchResult.Should().NotBeNull();
        searchResult.JsonExtensionData.Should().BeNull();

        searchResult.Posts.Should().NotBeNull();
        searchResult.Posts.Should().HaveCount(1);
        searchResult.Posts[0].MediaType.Should().Be("image");

        searchResult.Total.Should().Be(1);
    }


}
