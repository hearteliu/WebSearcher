using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSearcher.Models;
using WebSearcher.Models.ViewModels;

namespace WebSearcher.Interfaces
{
    public interface ISearchResultsViewModelBuilder
    {
        /// <summary>
        /// Builds the search results view model out of HomePageViewModel
        /// </summary>
        /// <param name="homePageViewModel">The home page view model</param>
        /// <returns>The search results view model</returns>
        SearchResultsViewModel GetSearchResultsViewModel(HomePageViewModel homePageViewModel);
    }
}