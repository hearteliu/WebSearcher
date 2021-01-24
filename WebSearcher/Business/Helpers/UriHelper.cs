using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSearcher.Resources.Enums;

namespace WebSearcher.Business.Helpers
{
    public static class UriHelper
    {
        /// <summary>
        /// Gets uri out of the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns></returns>
        public static Uri GetUriOutOfString(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            Uri uri;

            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri))
                return uri;

            return null;
        }
    }
}