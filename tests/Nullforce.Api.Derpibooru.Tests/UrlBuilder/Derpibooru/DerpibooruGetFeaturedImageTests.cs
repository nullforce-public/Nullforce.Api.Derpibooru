using Nullforce.Api.UrlBuilder.Derpibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Derpibooru;

public class DerpibooruGetFeaturedImageTests
{
    private readonly DerpiClient _client = new();

    [Fact]
    public void GetFeaturedImage_BuildsUrl()
    {
        var uri = _client
            .GetFeaturedImage()
            .Uri;

        uri.Should().Be("https://derpibooru.org/api/v1/json/images/featured");
    }
}
