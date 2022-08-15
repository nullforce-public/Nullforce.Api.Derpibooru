namespace Nullforce.Api.UrlBuilder.Twibooru;

public abstract class TwibooruBase
{
    protected readonly string _apiBaseUri;
    protected readonly string _apiKey;
    protected string _uri;
    public string Uri => _uri;

    public TwibooruBase(string apiBaseUri, string apiKey)
    {
        _apiBaseUri = apiBaseUri;
        _apiKey = apiKey;
    }
}
