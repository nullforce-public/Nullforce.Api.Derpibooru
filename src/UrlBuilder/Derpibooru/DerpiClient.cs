namespace Nullforce.Api.UrlBuilder.Derpibooru;

public class DerpiClient
{
    private readonly string _apiBaseUri = "https://derpibooru.org/api/v1/json";
    private readonly string _apiKey;

    public DerpiClient()
    {
    }

    public DerpiClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// Gets the image response for an image by Id
    /// </summary>
    /// <param name="imageId">The id of the image</param>
    /// <returns>A fluent API wrapper for get image</returns>
    public DerpiGetImage GetImage(int imageId)
    {
        return new DerpiGetImage(_apiBaseUri, _apiKey, imageId);
    }

    /// <summary>
    /// Gets the image response for the featured image
    /// </summary>
    /// <returns>A fluent API wrapper for featured image</returns>
    public DerpiGetFeaturedImage GetFeaturedImage()
    {
        return new DerpiGetFeaturedImage(_apiBaseUri, _apiKey);
    }

    /// <summary>
    /// Exposes the Derpibooru Search as a Fluent API.
    /// </summary>
    /// <returns>A fluent API wrapper for search</returns>
    public DerpiSearch Search()
    {
        return new DerpiSearch(_apiBaseUri, _apiKey);
    }
}
