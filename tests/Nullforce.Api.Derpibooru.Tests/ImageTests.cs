using Nullforce.Api.Derpibooru.JsonModels;

namespace Nullforce.Api.Derpibooru.Tests;

public class ImageTests
{
    private readonly DerpiClient _client = new ();

    public ImageTests()
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
    public async Task GetImage_WithId_ShouldReturnImageRoot()
    {
        const int ImageId = 1;

        var imageRoot = await _client
            .GetImage(ImageId)
            .WithFilterId((int) DerpiSystemFilter.Default)
            .Uri
            .GetJsonAsync<ImageRootJson>();

        imageRoot.Should().NotBeNull();
        imageRoot.Image.Should().NotBeNull();
        imageRoot.Image.Id.Should().Be(ImageId);
    }

    [Fact]
    [Trait(TestConstants.Category, TestConstants.DerpibooruCall)]
    public async Task GetFeaturedImage_ShouldReturnImageRoot()
    {
        var imageRoot = await _client
            .GetFeaturedImage()
            .Uri
            .GetJsonAsync<ImageRootJson>();

        imageRoot.Should().NotBeNull();
        imageRoot.Image.Should().NotBeNull();
    }
}
