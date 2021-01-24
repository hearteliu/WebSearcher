namespace WebSearcher.Models.Search
{
    public class ParsedResult
    {
        /// <summary>
        /// The url specific to the search result
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The description specific to the search result
        /// </summary>
        public string Description { get; set; }
    }
}