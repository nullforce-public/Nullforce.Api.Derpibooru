using Flurl;

namespace Nullforce.Api.UrlBuilder.Twibooru;

public class TwibooruSearch : TwibooruBase, ISearch
{
    public TwibooruSearch(string apiBaseUri, string apiKey)
        : base(apiBaseUri, apiKey)
    {
        _uri = apiBaseUri.AppendPathSegment("search/posts");

        // Setup defaults
        _uri = _uri
            .SetQueryParam("q", "*")
            .SetQueryParam("sf", "created_at")
            .SetQueryParam("sd", "desc");

        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            _uri = _uri.SetQueryParam("key", apiKey);
        }
    }

    public ISearch Page(int page)
    {
        _uri = _uri.SetQueryParam("page", page);
        return this;
    }

    public ISearch PerPage(int limit)
    {
        _uri = _uri.SetQueryParam("per_page", limit);
        return this;
    }

    public ISearch SortAscending()
    {
        _uri = _uri.SetQueryParam("sd", "asc");
        return this;
    }

    public ISearch SortBy(string sort)
    {
        _uri = _uri.SetQueryParam("sf", sort);
        return this;
    }

    public ISearch SortDescending()
    {
        _uri = _uri.SetQueryParam("sd", "desc");
        return this;
    }

    public ISearch WithFilterId(int filterId)
    {
        _uri = _uri.SetQueryParam("filter_id", filterId);
        return this;
    }

    public ISearch WithQuery(string query)
    {
        _uri = _uri.SetQueryParam("q", query);
        return this;
    }
}
