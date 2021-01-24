using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSearcher.Models.Search
{
    public class SearchResult
    {
        /// <summary>
        /// The url of the search result
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The description of the search result
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The position of the result in the returned results
        /// </summary>
        public int Position { get; set; }
    }
}