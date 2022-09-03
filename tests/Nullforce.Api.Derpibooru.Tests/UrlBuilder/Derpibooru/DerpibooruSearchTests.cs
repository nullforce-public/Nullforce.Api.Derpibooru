using System.Runtime.InteropServices;
using Nullforce.Api.UrlBuilder.Derpibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Derpibooru;

public class DerpibooruSearchTests
{
    private readonly DerpiClient _client = new();

    [Fact]
    public void Search_BuildsUrl()
    {
        var uri = _client.Search().Uri;

        uri.Should().Be("https://derpibooru.org/api/v1/json/search/images?q=%2A&sf=created_at&sd=desc");
    }

    [Theory]
    [InlineData(DerpiSortOptions.AspectRatio, "aspect_ratio")]
    [InlineData(DerpiSortOptions.Comments, "comment_count")]
    [InlineData(DerpiSortOptions.CreatedAt, "created_at")]
    [InlineData(DerpiSortOptions.FileSize, "size")]
    [InlineData(DerpiSortOptions.FirstSeenAt, "first_seen_at")]
    [InlineData(DerpiSortOptions.Relevance, "_score")]
    [InlineData(DerpiSortOptions.TagCount, "tag_count")]
    [InlineData(DerpiSortOptions.UpdatedAt, "updated_at")]
    [InlineData(DerpiSortOptions.Wilson, "wilson_score")]
    [InlineData(DerpiSortOptions.WilsonScore, "wilson_score")]
    public void Search_SortByDerpiSortOptions_BuildsUrl(
        DerpiSortOptions sortOptions,
        string sortText)
    {
        var uri = _client
            .Search()
            .SortBy(sortOptions)
            .Uri;

        uri.Should().Contain($"sf={sortText}");
    }

    [Fact]
    public void Search_SortDescending_BuildsUrl()
    {
        var uri = _client
            .Search()
            .SortDescending()
            .Uri;

        uri.Should().Contain("sd=desc");
    }

    [Fact]
    public void Search_WithFilterId_BuildsUrl()
    {
        var uri = _client
            .Search()
            .WithFilterId(DerpiSystemFilter.Default)
            .Uri;

        uri.Should().Contain($"filter_id={(int)DerpiSystemFilter.Default}");
    }

    [Fact]
    public void Search_WithKey_BuildsUrlWithKey()
    {
        var uri = (new DerpiClient("apikey")).Search().Uri;

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
