using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSearcher.Models.Search
{
    public class SearchResultConfiguration
    {
        /// <summary>
        /// The XPath to the result's URL
        /// </summary>
        public string UrlXPath { get; set; }

        /// <summary>
        /// The XPath to the result's description
        /// </summary>
        public string DescriptionXPath { get; set; }

        /// <summary>
        /// The XPath to the search result node
        /// </summary>
        public string ResultXPath { get; set; }
    }
}