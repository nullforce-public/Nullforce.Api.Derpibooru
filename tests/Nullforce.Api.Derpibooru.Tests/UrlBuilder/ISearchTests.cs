using Nullforce.Api.UrlBuilder;
using Nullforce.Api.UrlBuilder.Derpibooru;
using Nullforce.Api.UrlBuilder.Twibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder;

public class ISearchTests
{
    private readonly DerpiClient _derpibooruClient = new();
    private readonly TwibooruClient _twibooruClient = new();

    [Fact]
    public void Search_IsInterchangeable()
    {
        var derpibooru = _derpibooruClient.Search();
        var twibooru = _twibooruClient.Search();

        var derpibooruSearchUri = UseSearch(derpibooru);
        var twibooruSearchUri = UseSearch(twibooru);

        using var _ = new AssertionScope();

        derpibooruSearchUri.Should().NotBeEmpty();
        twibooruSearchUri.Should().NotBeEmpty();
    }

    private string UseSearch(ISearch search)
    {
        return search
            .WithQuery("test")
            .WithFilterId(1)
            .SortBy("created_at")
            .SortAscending()
            .Page(1)
            .PerPage(50)
            .Uri;
    }
}
