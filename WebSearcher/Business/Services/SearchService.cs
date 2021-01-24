using System;
using System.Collections.Generic;
using System.Linq;
using WebSearcher.Business.Helpers;
using WebSearcher.Interfaces;
using WebSearcher.Interfaces.Services;
using WebSearcher.Models.Search;
using WebSearcher.Resources.Enums;

namespace WebSearcher.Business.Services
{
    public class SearchService : ISearchService
    {
        private readonly IParser parser;
        private readonly IBrowserService browserService;

        public SearchService(IParser parser, IBrowserService browserService)
        {
            this.parser = parser;
            this.browserService = browserService;
        }

        /// <summary>
        /// Performs the search of the searchPhrase
        /// </summary>
        /// <param name="searchPhrase">The search phrase</param>
        /// <param name="searchUrl">The search url</param>
        /// <param name="searchEngine">The search engine to use</param>
        /// <returns>A list of SearchResult</returns>
        public List<SearchResult> Search(string searchPhrase, string searchUrl, SearchEnginesEnum searchEngine)
        {
            var searchResults = new List<SearchResult>();

            var searchedUri = UriHelper.GetUriOutOfString(searchUrl);

            var searchResultConfiguration = GetSearchResultConfiguration(searchEngine);

            var searchEnginehUrl = GetSearchEngineUrl(searchPhrase, searchEngine);

            var html = browserService.GetHtml(searchEnginehUrl);

            if (string.IsNullOrEmpty(html))
                return searchResults;

            var parsedResults = parser.ParseHtml(html, searchResultConfiguration);

            if (parsedResults == null || !parsedResults.Any())
                return searchResults;

            for (int i = 0; i < parsedResults.Count; i++)
            {
                var parsedResult = parsedResults[i];

                if (parsedResult.Url.Contains(searchedUri.Host))
                {
                    var searchResult = new SearchResult()
                    {
                        Description = parsedResult.Description,
                        Url = GetParsedResultUrl(parsedResult.Url, searchEngine),
                        Position = i + 1
                    };

                    searchResults.Add(searchResult);
                }
            }

            return searchResults;
        }

        /// <summary>
        /// Gets the search result configuration
        /// </summary>
        /// <param name="searchEngine">The search Engine</param>
        /// <returns>An object containing XPaths specific to the search engine</returns>
        private SearchResultConfiguration GetSearchResultConfiguration(SearchEnginesEnum searchEngine)
        {
            var searchResultConfiguration = new SearchResultConfiguration();

            switch (searchEngine)
            {
                case SearchEnginesEnum.Google:
                    {
                        searchResultConfiguration.ResultXPath = Resources.Constants.Constants.XPaths.Google.SearchResultsNodeXPath;
                        searchResultConfiguration.DescriptionXPath = Resources.Constants.Constants.XPaths.Google.DescriptionNodeXPath;
                        searchResultConfiguration.UrlXPath = Resources.Constants.Constants.XPaths.Google.UrlXPath;
                    }
                    break;

                case SearchEnginesEnum.Bing:
                    {
                        searchResultConfiguration.ResultXPath = Resources.Constants.Constants.XPaths.Bing.SearchResultsNodeXPath;
                        searchResultConfiguration.DescriptionXPath = Resources.Constants.Constants.XPaths.Bing.DescriptionNodeXPath;
                        searchResultConfiguration.UrlXPath = Resources.Constants.Constants.XPaths.Bing.UrlXPath;
                    }
                    break;

                case SearchEnginesEnum.Yahoo:
                    {
                        searchResultConfiguration.ResultXPath = Resources.Constants.Constants.XPaths.Yahoo.SearchResultsNodeXPath;
                        searchResultConfiguration.DescriptionXPath = Resources.Constants.Constants.XPaths.Yahoo.DescriptionNodeXPath;
                        searchResultConfiguration.UrlXPath = Resources.Constants.Constants.XPaths.Yahoo.UrlXPath;
                    }
                    break;
            }

            return searchResultConfiguration;
        }

        /// <summary>
        /// Gets the search engine Url
        /// </summary>
        /// <param name="searchPhrase">Search phrase</param>
        /// <param name="searchEngine">The search engine</param>
        /// <returns>The formatted url</returns>
        private string GetSearchEngineUrl(string searchPhrase, SearchEnginesEnum searchEngine)
        {
            var searchEngineUrl = string.Empty;

            switch (searchEngine)
            {
                case SearchEnginesEnum.Google:
                    {
                        searchEngineUrl =
                            FormatSearchEngineUrl(Resources.Constants.Constants.SearchUrls.Google, searchPhrase);
                    }
                    break;

                case SearchEnginesEnum.Bing:
                    {
                        searchEngineUrl =
                            FormatSearchEngineUrl(Resources.Constants.Constants.SearchUrls.Bing, searchPhrase);
                    }
                    break;

                case SearchEnginesEnum.Yahoo:
                    {
                        searchEngineUrl =
                            FormatSearchEngineUrl(Resources.Constants.Constants.SearchUrls.Yahoo, searchPhrase);
                    }
                    break;
            }

            return searchEngineUrl;
        }

        /// <summary>
        /// Formats the search engine url
        /// </summary>
        /// <param name="url">The search engine url template</param>
        /// <param name="searchPhrase">The search phrase</param>
        /// <returns>The formatted url</returns>
        private string FormatSearchEngineUrl(string url, string searchPhrase)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(searchPhrase))
                return string.Empty;

            var formattedSearchPhrase = searchPhrase.Replace(' ', '+');

            return string.Format(url, formattedSearchPhrase);
        }

        /// <summary>
        /// Parses the result urls and for google dig the url from it's neighbouringh characters.
        /// For all other search engines return the url.
        /// </summary>
        /// <param name="url">The url</param>
        /// <param name="searchEngine">The search engine</param>
        /// <returns>The parsed result url</returns>
        private string GetParsedResultUrl(string url, SearchEnginesEnum searchEngine)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            switch (searchEngine)
            {
                case SearchEnginesEnum.Google:
                    {
                        var groups = url.Split(new string[]
                                                    {
                                                        WebSearcher.Resources.Constants.Constants.Common.Ampersand 
                                                    }, StringSplitOptions.None);

                        if (groups != null && groups.Length != 0)
                        {
                            var firstGroup = groups[0];

                            if (firstGroup.StartsWith(WebSearcher.Resources.Constants.Constants.Common.GoogleResultTrimStartCharacters))
                                url = firstGroup.Substring(7);
                        }

                    }
                    break;
            }

            return url;

        }
    }
}