using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using WebSearcher.Interfaces;
using WebSearcher.Models.Search;
using WebSearcher.Resources.Enums;

namespace WebSearcher.Business.Parsers
{
    public class Parser : IParser
    {
        /// <summary>
        /// Parses the html passed as parameter based on the search result configuration.
        /// </summary>
        /// <param name="html">The html</param>
        /// <param name="searchResultConfiguration">An object containing the XPaths to the searched fields.</param>
        /// <returns></returns>
        public List<ParsedResult> ParseHtml(string html, SearchResultConfiguration searchResultConfiguration)
        {
            var parsedResults = new List<ParsedResult>();

            if (string.IsNullOrEmpty(html))
                return parsedResults;

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            var root = htmlDocument.DocumentNode;

            if (root == null)
                return parsedResults;

            var resultNodes = root.SelectNodes(searchResultConfiguration.ResultXPath);

            if (resultNodes == null || !resultNodes.Any())
                return parsedResults;

            parsedResults = GetParsedResults(resultNodes, searchResultConfiguration);

            return parsedResults;
        }

        private List<ParsedResult> GetParsedResults(HtmlNodeCollection nodeCollection, SearchResultConfiguration searchResultConfiguration)
        {
            var parsedResults = new List<ParsedResult>();

            if (nodeCollection == null || !nodeCollection.Any())
                return parsedResults;

            foreach (var resultNode in nodeCollection)
            {
                var parsedResult = new ParsedResult();

                var resultNodeHtml = new HtmlDocument();

                if (string.IsNullOrEmpty(resultNode.InnerHtml))
                    continue;

                resultNodeHtml.LoadHtml(resultNode.InnerHtml);


                var descriptionNode = resultNodeHtml.DocumentNode.SelectNodes(searchResultConfiguration.DescriptionXPath);

                if (descriptionNode == null || !descriptionNode.Any())
                    continue;

                parsedResult.Description = descriptionNode[0].InnerText;

                var urlNode = resultNodeHtml.DocumentNode.SelectNodes(searchResultConfiguration.UrlXPath);

                if (urlNode == null || !urlNode.Any())
                    continue;

                var href = urlNode[0].Attributes[Resources.Constants.Constants.Common.HrefAttribute];

                if (href == null || string.IsNullOrEmpty(href.Value))
                    continue;

                parsedResult.Url = href.Value;

                parsedResults.Add(parsedResult);
            }

            return parsedResults;
        }
    }
}