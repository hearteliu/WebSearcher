using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSearcher.Resources.Constants
{
    public static class Constants
    {
        public static partial class Labels
        {
            public const string SearchPhraseLabel = "Search phrase";

            public const string UrlLabel = "URL";

            public const string SearchButtonLabel = "Search";

            public const string AppTitleLabel = "Web Searcher";

            public const string SearchGoogleLabel = "We're searching on Google by default. Please select extra search engines:";

            public const string SearchBingLabel = "Search Bing";

            public const string SearchYahooLabel = "Search Yahoo";

            public const string YouSearchedForLabel = "You searched for";

            public const string PerformANewSearch = "Perform a new search";

            public const string ReturnedNoResults = " returned no results!";

            public const string Rank = "Rank";

        }


        public static partial class SearchUrls
        {
            public const string Google = "https://www.google.co.uk/search?q={0}&num=100";

            public const string Bing = "https://www.bing.com/search?q={0}&count=100";

            public const string Yahoo = "https://sg.search.yahoo.com/search?p={0}&n=100";
        }

        public static partial class XPaths
        {
            public static partial class Google
            {
                public const string SearchResultsNodeXPath = "//*[@id=\"main\"]/div";

                public const string DescriptionNodeXPath = "//div/div[3]/div/div/div/div/div/text()";

                public const string UrlXPath = "//div/div[1]/a";
            }

            public static partial class Bing
            {
                public const string SearchResultsNodeXPath = "//*[@id=\"b_results\"]/li";

                public const string DescriptionNodeXPath = "//div/p";

                public const string UrlXPath = "//h2/a";
            }

            public static partial class Yahoo
            {
                public const string SearchResultsNodeXPath = "//*[@id=\"web\"]/ol/li";

                public const string DescriptionNodeXPath = "//div/div[2]/p";

                public const string UrlXPath = "//div/div[1]/h3/a";
            }
        }

        public static partial class Common
        {
            public const string SearchResultsViewName = "SearchResults";

            public const string HrefAttribute = "href";

            public const string IndexAction = "Index";

            public const string HomeController = "Home";

            public const string Http = "http";

            public const string Https = "https";

            public const string Ampersand = "&amp;";

            public const string GoogleResultTrimStartCharacters = "/url?q=";
        }

        public static partial class Errors
        {
            public const string PleaseEnterSearchPhrase = "Please, enter a search phrase";

            public const string PleaseEnterUrl = "Please, enter a URL";

            public const string PleaseEnterAValidUrl = "Please, enter a valid URL";
        }

        public static partial class Regex
        {
            public const string UrlValidatorRegex = @"(http://)?(www\.)?\w+\.(com|net|edu|org)";
        }
    }
}