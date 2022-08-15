using Nullforce.Api.UrlBuilder.Twibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Twibooru;

public class TwibooruSearchTests
{
    private readonly TwibooruClient _client = new();
    private readonly TwibooruSearch _search = new("https://twibooru.org/api/v3", string.Empty);

    [Fact]
    public void Search_BuildsUrl()
    {
        var uri = _client.Search().Uri;

        uri.Should().Be("https://twibooru.org/api/v3/search/posts?q=%2A&sf=created_at&sd=desc");
    }

    [Fact]
    public void Search_WithKey_BuildsUrlWithKey()
    {
        var uri = (new TwibooruClient("apikey")).Search().Uri;

        uri.Should().Contain("key=apikey");
    }

    [Fact]
    public void Search_WithParameters_BuildsUrl()
    {
        var uri = _client
            .Search()
            .WithQuery("fluttershy")
            .WithFilterId(1)
            .SortBy("created_at")
            .SortAscending()
            .Page(1)
            .PerPage(50)
            .Uri;

        using var _ = new AssertionScope();

        uri.Should().Contain("q=fluttershy")
            .And.Contain("filter_id=1")
            .And.Contain("sf=created_at")
            .And.Contain("sd=asc")
            .And.Contain("page=1")
            .And.Contain("per_page=50");
    }
}
