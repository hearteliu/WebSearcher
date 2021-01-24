using System;
using System.Collections.Generic;
using WebSearcher.Models.Search;
using WebSearcher.Resources.Enums;

namespace WebSearcher.Interfaces.Services
{
    public interface ISearchService
    {
        /// <summary>
        /// Performs the search of the searchPhrase
        /// </summary>
        /// <param name="searchPhrase">The search phrase</param>
        /// <param name="searchUrl">The search url</param>
        /// <param name="searchEngine">The search engine to use</param>
        /// <returns>A list of SearchResult</returns>
        List<SearchResult> Search(string searchPhrase, string url, SearchEnginesEnum searchEngine);
    }
}