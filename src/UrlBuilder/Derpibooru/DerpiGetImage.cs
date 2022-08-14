using Flurl;

namespace Nullforce.Api.UrlBuilder.Derpibooru;

public class DerpiGetImage : DerpiBase, IGetImage
{
    public DerpiGetImage(string apiBaseUri, string apiKey, int imageId)
        : base(apiBaseUri, apiKey)
    {
        _uri = apiBaseUri.AppendPathSegment($"images/{imageId}");
    }

    /// <summary>
    /// Applies a Derpibooru filter
    /// </summary>
    /// <param name="filterId">A user or system filter ID (See https://www.derpibooru.org/filters)</param>
    public IGetImage WithFilterId(int filterId)
    {
        _uri = _uri.SetQueryParam("filter_id", filterId);
        return this;
    }
}
