using Nullforce.Api.UrlBuilder.Derpibooru;

namespace Nullforce.Api.Derpibooru.Tests.UrlBuilder.Derpibooru;

public class DerpibooruGetImageTests
{
    private readonly DerpiClient _client = new ();

    [Fact]
    public void GetImage_BuildsUrl()
    {
        var uri = _client.GetImage(1).Uri;

        uri.Should().Be("https://derpibooru.org/api/v1/json/images/1");
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
