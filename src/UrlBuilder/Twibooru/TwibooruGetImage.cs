using Flurl;

namespace Nullforce.Api.UrlBuilder.Twibooru;

public class TwibooruGetImage : TwibooruBase, IGetImage
{
    public TwibooruGetImage(string apiBaseUri, string apiKey, int imageId)
        : base(apiBaseUri, apiKey)
    {
        _uri = apiBaseUri.AppendPathSegment($"images/{imageId}");
    }

    /// <summary>
    /// Applies a Twibooru filter
    /// </summary>
    /// <param name="filterId">A user or system filter ID</param>
    public IGetImage WithFilterId(int filterId)
    {
        _uri = _uri.SetQueryParam("filter_id", filterId);
        return this;
    }
}
