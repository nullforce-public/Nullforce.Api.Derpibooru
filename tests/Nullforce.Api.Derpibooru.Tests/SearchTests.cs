using System;
using System.Threading.Tasks;
using FluentAssertions;
using Flurl;
using Flurl.Http;
using Nullforce.Api.Derpibooru.JsonModels;
using Xunit;

namespace Nullforce.Api.Derpibooru.Tests
{
    public class SearchTests
    {
        const string Category = "Category";
        const string DerpibooruCall = "DerpibooruCall";

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void SearchRawUri()
        {
            var uri = "https://derpibooru.org/search.json";
            uri = uri.SetQueryParam("q", "fluttershy");
            SearchRootJson searchResult = null;

            Func<Task> act = async () =>
            {
                searchResult = await uri.GetJsonAsync<SearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void Search_WithDefaultExample_ReturnsResults()
        {
            var derpiClient = new DerpiClient();
            SearchRootJson searchResult = null;

            var uri = derpiClient.Search().Uri;

            Func<Task> act = async () =>
            {
                searchResult = await derpiClient
                    .Search()
                    .Uri
                    .GetJsonAsync<SearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void Search_ByTag_ReturnsResults()
        {
            var derpiClient = new DerpiClient();
            SearchRootJson searchResult = null;

            var uri = derpiClient.Search().Uri;

            Func<Task> act = async () =>
            {
                searchResult = await derpiClient
                    .Search()
                    .WithQuery("rarity AND twilight sparkle")
                    .Uri
                    .GetJsonAsync<SearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void Search_ByRandom_ReturnsResults()
        {
            var derpiClient = new DerpiClient();
            SearchRootJson searchResult = null;
            SearchRootJson searchResult2 = null;

            var uri = derpiClient.Search().Uri;

            Func<Task> act = async () =>
            {
                searchResult = await derpiClient
                    .Search()
                    .SortBy("random")
                    .Uri
                    .GetJsonAsync<SearchRootJson>();

                searchResult2 = await derpiClient
                    .Search()
                    .SortBy("random")
                    .Uri
                    .GetJsonAsync<SearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
            searchResult2.Should().NotBeNull();
            searchResult.Should().NotBe(searchResult2);
        }

        [Fact]
        public void Search_WithApiKey_HasKeyParam()
        {
            const string ApiKey = "apikey";
            var derpiClient = new DerpiClient(ApiKey);

            var uri = derpiClient.Search().Uri;

            uri.Should().Contain($"key={ApiKey}");
        }

        [Fact]
        public void Search_WithoutApiKey_HasNoKeyParam()
        {
            var derpiClient = new DerpiClient();

            var uri = derpiClient.Search().Uri;

            uri.Should().NotContain("key=");
        }
    }
}
