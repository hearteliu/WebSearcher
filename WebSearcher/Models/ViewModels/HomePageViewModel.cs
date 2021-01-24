using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSearcher.Business.Validators;

namespace WebSearcher.Models
{
    public class HomePageViewModel
    {
        /// <summary>
        /// The search phrase
        /// </summary>
        [Required(ErrorMessage = Resources.Constants.Constants.Errors.PleaseEnterSearchPhrase)]
        public string SearchPhrase { get; set; }

        /// <summary>
        /// The URL
        /// </summary>
        [Url]
        [UrlValidator]
        [Required(ErrorMessage = Resources.Constants.Constants.Errors.PleaseEnterUrl)]
        public string Url { get; set; }

        /// <summary>
        /// A value indicating Bing search is requested
        /// </summary>
        public bool SearchBing { get; set; }

        /// <summary>
        /// A value indicating Yahoo search is requested
        /// </summary>
        public bool SearchYahoo { get; set; }

    }
}