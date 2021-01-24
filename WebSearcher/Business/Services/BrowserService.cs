using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebSearcher.Interfaces.Services;

namespace WebSearcher.Business.Services
{
    public class BrowserService : IBrowserService
    {
        /// <summary>
        /// Gets the html of the url specified
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The html of the page</returns>
        public string GetHtml(string url)
        {
            var html = string.Empty;

            if (string.IsNullOrEmpty(url))
                return string.Empty;

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    html = webClient.DownloadString(url);
                }
            }
            catch
            {
                return html;
            }

            return html;
        }
    }
}