using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSearcher.Models.Search
{
    public class SearchEngineResult
    {
        /// <summary>
        /// The search engine
        /// </summary>
        public string SearchEngine { get; set; }

        /// <summary>
        /// The search results list
        /// </summary>
        public List<SearchResult> SearchResults { get; set; }
    }
}