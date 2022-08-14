using Flurl;

namespace Nullforce.Api.UrlBuilder.Derpibooru;

public class DerpiGetFeaturedImage : DerpiBase, IGetFeaturedImage
{
    public DerpiGetFeaturedImage(string apiBaseUri, string apiKey)
        : base(apiBaseUri, apiKey)
    {
        _uri = apiBaseUri.AppendPathSegment("images/featured");
    }
}
