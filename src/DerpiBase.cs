namespace Nullforce.Api.Derpibooru
{
    public class DerpiBase
    {
        protected readonly string _apiBaseUri;
        protected readonly string _apiKey;
        protected string _uri;
        public string Uri => _uri;

        public DerpiBase(string apiBaseUri, string apiKey)
        {
            _apiBaseUri = apiBaseUri;
            _apiKey = apiKey;
        }
    }
}
