using Flurl;

namespace Nullforce.Api.Derpibooru;

public class DerpiGetImage : DerpiBase
{
    public DerpiGetImage(string apiBaseUri, string apiKey, int imageId)
        : base(apiBaseUri, apiKey)
    {
        _uri = apiBaseUri.AppendPathSegment($"images/{imageId}");
    }

    /// <summary>
    /// Applies a Derpibooru filter
    /// </summary>
    /// <param name="filterId">A user or system filter ID (See https://www.derpibooru.org/filters) </param>
    public DerpiGetImage WithFilterId(int filterId)
    {
        _uri = _uri.SetQueryParam("filter_id", filterId);
        return this;
    }
}
