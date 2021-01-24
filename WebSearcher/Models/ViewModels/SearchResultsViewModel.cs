using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSearcher.Models.Search;
using WebSearcher.Resources.Enums;

namespace WebSearcher.Models.ViewModels
{
    public class SearchResultsViewModel
    {
        /// <summary>
        /// The search phrase
        /// </summary>
        public string SearchPhrase { get; set; }

        /// <summary>
        /// The URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The list of search engine results
        /// </summary>
        public List<SearchEngineResult> SearchEngineResults { get; set; }
    }
}