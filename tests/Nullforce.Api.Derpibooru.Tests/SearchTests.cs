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

        public SearchTests()
        {
            // Do this in Startup. All calls to the URI will use the same HttpClient instance.
            FlurlHttp.ConfigureClient("https://derpibooru.org/api/v1/json", cli => cli
                .WithHeaders(new
                {
                    Accept = "application/json",
                    User_Agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36" // Flurl will convert that underscore to a hyphen
                }));
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void SearchRawUri()
        {
            var uri = "https://derpibooru.org/api/v1/json/search/images";
            uri = uri.SetQueryParam("q", "fluttershy");
            ImageSearchRootJson searchResult = null;

            Func<Task> act = async () =>
            {
                searchResult = await uri.GetJsonAsync<ImageSearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void Search_WithDefaultExample_ReturnsResults()
        {
            var derpiClient = new DerpiClient();
            ImageSearchRootJson searchResult = null;

            var uri = derpiClient.Search().Uri;

            Func<Task> act = async () =>
            {
                searchResult = await derpiClient
                    .Search()
                    .Uri
                    .GetJsonAsync<ImageSearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void Search_ByTag_ReturnsResults()
        {
            var derpiClient = new DerpiClient();
            ImageSearchRootJson searchResult = null;

            var uri = derpiClient.Search().Uri;

            Func<Task> act = async () =>
            {
                searchResult = await derpiClient
                    .Search()
                    .WithQuery("rarity AND twilight sparkle")
                    .Uri
                    .GetJsonAsync<ImageSearchRootJson>();
            };

            act.Should().NotThrow();
            searchResult.Should().NotBeNull();
        }

        [Fact]
        [Trait(Category, DerpibooruCall)]
        public void Search_ByRandom_ReturnsResults()
        {
            var derpiClient = new DerpiClient();
            ImageSearchRootJson searchResult = null;
            ImageSearchRootJson searchResult2 = null;

            var uri = derpiClient.Search().Uri;

            Func<Task> act = async () =>
            {
                searchResult = await derpiClient
                    .Search()
                    .SortBy("random")
                    .Uri
                    .GetJsonAsync<ImageSearchRootJson>();

                searchResult2 = await derpiClient
                    .Search()
                    .SortBy("random")
                    .Uri
                    .GetJsonAsync<ImageSearchRootJson>();
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
