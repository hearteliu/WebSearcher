using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSearcher.Models.Search;
using WebSearcher.Resources.Enums;

namespace WebSearcher.Interfaces
{
    public interface IParser
    {
        List<ParsedResult> ParseHtml(string html, SearchResultConfiguration searchResultConfiguration);
    }
}