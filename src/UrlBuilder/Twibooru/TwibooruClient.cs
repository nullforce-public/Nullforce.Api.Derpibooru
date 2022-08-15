namespace Nullforce.Api.UrlBuilder.Twibooru;

public class TwibooruClient
{
    private readonly string _apiBaseUri = "https://twibooru.org/api/v3";
    private readonly string _apiKey;

    public TwibooruClient()
    {
    }

    public TwibooruClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public TwibooruGetImage GetImage(int imageId)
    {
        return new TwibooruGetImage(_apiBaseUri, _apiKey, imageId);
    }

    /// <summary>
    /// Gets the image response for the featured image
    /// </summary>
    /// <returns>A fluent API wrapper for featured image</returns>
    public TwibooruGetFeaturedImage GetFeaturedImage()
    {
        return new TwibooruGetFeaturedImage(_apiBaseUri, _apiKey);
    }

    /// <summary>
    /// Exposes the Twibooru Search as a Fluent API.
    /// </summary>
    /// <returns>A fluent API wrapper for search</returns>
    public TwibooruSearch Search()
    {
        return new TwibooruSearch(_apiBaseUri, _apiKey);
    }
}
