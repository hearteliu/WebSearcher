namespace WebSearcher.Interfaces.Services
{
    public interface IBrowserService
    {
        /// <summary>
        /// Gets the html of the url specified
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The html of the page</returns>
        string GetHtml(string url);
    }
}