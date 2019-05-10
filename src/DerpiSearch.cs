﻿using Flurl;

namespace Nullforce.Api.Derpibooru
{
    public class DerpiSearch : DerpiBase
    {
        public DerpiSearch(string apiBaseUri, string apiKey)
            : base(apiBaseUri, apiKey)
        {
            _uri = apiBaseUri.AppendPathSegment("search.json");

            _uri = _uri
                .SetQueryParam("q", "*")
                .SetQueryParam("sf", "created_at")
                .SetQueryParam("sd", "desc")
                .SetQueryParam("key", apiKey);
        }

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
        /// <param name="query">A query string following the syntax at https://derpibooru.org/search/syntax </param>
        public DerpiSearch WithQuery(string query)
        {
            // TODO: query validation
            _uri = _uri.SetQueryParam("q", query);
            return this;
        }

        /// <summary>
        /// Applies a Derpibooru filter
        /// </summary>
        /// <param name="filterId">A user or system filter ID (See https://www.derpibooru.org/filters) </param>
        public DerpiSearch WithFilterId(int filterId)
        {
            _uri = _uri.SetQueryParam("filter_id", filterId);
            return this;
        }

        /// <summary>
        /// Applies a Derpibooru system filter
        /// </summary>
        /// <param name="filter">A system filter (See https://www.derpibooru.org/filters) </param>
        public DerpiSearch WithFilterId(DerpiSystemFilter filter)
        {
            return WithFilterId((int)filter);
        }

        /// <summary>
        /// Applies a Derpibooru sort option
        /// </summary>
        /// <param name="sortOption">A sort option</param>
        public DerpiSearch SortBy(string sort)
        {
            _uri = _uri.SetQueryParam("sf", sort);
            return this;
        }

        /// <summary>
        /// Applies a Derpibooru sort option
        /// </summary>
        /// <param name="sortOption">A sort option</param>
        public DerpiSearch SortBy(DerpiSortOptions sortOption)
        {
            string sort = string.Empty;

            switch (sortOption)
            {
                case DerpiSortOptions.CreatedAt:
                    sort = "created_at";
                    break;
                case DerpiSortOptions.UpdatedAt:
                    sort = "updated_at";
                    break;
                case DerpiSortOptions.FirstSeenAt:
                    sort = "first_seen_at";
                    break;
                case DerpiSortOptions.TagCount:
                    sort = "tag_count";
                    break;
                default:
                    sort = sortOption.ToString().ToLower();
                    break;
            }

            return SortBy(sort);
        }

        /// <summary>
        /// Sorts the results in ascending order
        /// </summary>
        public DerpiSearch SortAscending()
        {
            _uri = _uri.SetQueryParam("sd", "asc");
            return this;
        }

        /// <summary>
        /// Sorts the results in descending order
        /// </summary>
        public DerpiSearch SortDescending()
        {
            _uri = _uri.SetQueryParam("sd", "desc");
            return this;
        }

        /// <summary>
        /// The page number for the search results
        /// </summary>
        /// <param name="page">A 1-indexed page number</param>
        /// <returns></returns>
        public DerpiSearch Page(int page)
        {
            _uri = _uri.SetQueryParam("page", page);
            return this;
        }

        /// <summary>
        /// The number of search results to return per page
        /// </summary>
        /// <param name="limit">A limit between 1 and 50</param>
        /// <returns></returns>
        public DerpiSearch PerPage(int limit)
        {
            _uri = _uri.SetQueryParam("perpage", limit);
            return this;
        }
    }
}
