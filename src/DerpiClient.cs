using System;

namespace Nullforce.Api.Derpibooru
{
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
        /// Exposes the Derpibooru Search as a Fluent API.
        /// </summary>
        /// <returns>A fluent API wrapper for Derpibooru search</returns>
        public DerpiSearch Search()
        {
            return new DerpiSearch(_apiBaseUri, _apiKey);
        }
    }
}
