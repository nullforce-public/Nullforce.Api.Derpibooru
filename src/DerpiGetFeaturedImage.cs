using Flurl;

namespace Nullforce.Api.Derpibooru
{
    public class DerpiGetFeaturedImage : DerpiBase
    {
        public DerpiGetFeaturedImage(string apiBaseUri, string apiKey)
            : base(apiBaseUri, apiKey)
        {
            _uri = apiBaseUri.AppendPathSegment("images/featured");
        }
    }
}
