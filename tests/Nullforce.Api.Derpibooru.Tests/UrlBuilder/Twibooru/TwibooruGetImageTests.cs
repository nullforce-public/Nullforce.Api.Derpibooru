using Nullforce.Api.UrlBuilder.Twibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Twibooru;

public class TwibooruGetImageTests
{
    private readonly TwibooruClient _client = new();

    [Fact]
    public void GetImage_BuildsUrl()
    {
        var uri = _client.GetImage(1).Uri;

        uri.Should().Be("https://twibooru.org/api/v3/images/1");
    }

    [Fact]
    public void GetImage_WithFilterId_BuildsUrl()
    {
        var uri = _client
            .GetImage(1)
            .WithFilterId(2)
            .Uri;

        uri.Should().Contain("filter_id=2");
    }
}
