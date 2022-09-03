namespace Nullforce.Api.UrlBuilder;

public interface ISearch
{
    public string Uri { get; }

    /// <summary>
    /// Specifies a search query filter
    /// </summary>
    /// <remarks>
    /// Search my favorites: my:faves, !my:faves
    /// Search my upvotes: my:upvotes, !my:upvotes
    /// Search my downvotes: my:downvotes, !my:downvotes
    /// Search my uploads: my:uploads, !my:uploads
    /// Search my watched: my:watched, !my:watched
    /// </remarks>
    /// <param name="query">A query string following the syntax at https://derpibooru.org/pages/search_syntax </param>
    public ISearch WithQuery(string query);

    /// <summary>
    /// Applies a Derpibooru filter
    /// </summary>
    /// <param name="filterId">A user or system filter ID (See https://www.derpibooru.org/filters) </param>
    public ISearch WithFilterId(int filterId);

    /// <summary>
    /// Applies a Derpibooru sort option
    /// </summary>
    /// <param name="sortOption">A sort option</param>
    public ISearch SortBy(string sortOption);

    /// <summary>
    /// Sorts the results in ascending order
    /// </summary>
    public ISearch SortAscending();

    /// <summary>
    /// Sorts the results in descending order
    /// </summary>
    public ISearch SortDescending();

    /// <summary>
    /// The page number for the search results
    /// </summary>
    /// <param name="page">A 1-indexed page number</param>
    public ISearch Page(int page);

    /// <summary>
    /// The number of search results to return per page
    /// </summary>
    /// <param name="limit">A limit between 1 and 50</param>
    public ISearch PerPage(int limit);
}
