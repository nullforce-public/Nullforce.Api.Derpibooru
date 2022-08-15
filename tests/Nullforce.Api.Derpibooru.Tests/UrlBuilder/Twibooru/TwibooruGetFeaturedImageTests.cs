using Nullforce.Api.UrlBuilder.Twibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Twibooru;

public class TwibooruGetFeaturedImageTests
{
    private readonly TwibooruClient _client = new();

    [Fact]
    public void GetFeaturedImage_BuildsUrl()
    {
        var uri = _client.GetFeaturedImage().Uri;

        uri.Should().Be("https://twibooru.org/api/v3/posts/featured");
    }
}
