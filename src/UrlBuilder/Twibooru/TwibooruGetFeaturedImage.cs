using Flurl;

namespace Nullforce.Api.UrlBuilder.Twibooru;

public class TwibooruGetFeaturedImage : TwibooruBase, IGetFeaturedImage
{
    public TwibooruGetFeaturedImage(string apiBaseUri, string apiKey)
        : base(apiBaseUri, apiKey)
    {
        _uri = apiBaseUri.AppendPathSegment("posts/featured");
    }
}
