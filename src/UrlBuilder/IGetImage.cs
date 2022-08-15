namespace Nullforce.Api.UrlBuilder;

public interface IGetImage
{
    public string Uri { get; }

    /// <summary>
    /// Applies a Derpibooru filter
    /// </summary>
    /// <param name="filterId">A user or system filter ID (See https://www.derpibooru.org/filters) </param>
    public IGetImage WithFilterId(int filterId);
}
