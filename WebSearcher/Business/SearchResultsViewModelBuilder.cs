using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSearcher.Interfaces;
using WebSearcher.Interfaces.Services;
using WebSearcher.Models;
using WebSearcher.Models.Search;
using WebSearcher.Models.ViewModels;

namespace WebSearcher.Business
{
    public class SearchResultsViewModelBuilder : ISearchResultsViewModelBuilder
    {
        private ISearchService searchService;

        public SearchResultsViewModelBuilder(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        /// <summary>
        /// Builds the search results view model out of HomePageViewModel
        /// </summary>
        /// <param name="homePageViewModel">The home page view model</param>
        /// <returns>The search results view model</returns>
        public SearchResultsViewModel GetSearchResultsViewModel(HomePageViewModel homePageViewModel)
        {
            var searchResultViewModel = new SearchResultsViewModel();

            if (homePageViewModel == null)
                return searchResultViewModel;

            searchResultViewModel.SearchPhrase = homePageViewModel.SearchPhrase;
            searchResultViewModel.Url = homePageViewModel.Url;

            var searchEngineResults = new List<SearchEngineResult>();


            var searchResults = searchService.Search(homePageViewModel.SearchPhrase,
                                                     homePageViewModel.Url,
                                                     Resources.Enums.SearchEnginesEnum.Google);

            var searchEngineResult = new SearchEngineResult()
            {
                SearchEngine = Resources.Enums.SearchEnginesEnum.Google.ToString(),
                SearchResults = searchResults
            };

            searchEngineResults.Add(searchEngineResult);

            if (homePageViewModel.SearchBing)
            {
                searchResults = searchService.Search(homePageViewModel.SearchPhrase,
                                                         homePageViewModel.Url,
                                                         Resources.Enums.SearchEnginesEnum.Bing);

                searchEngineResult = new SearchEngineResult()
                {
                    SearchEngine = Resources.Enums.SearchEnginesEnum.Bing.ToString(),
                    SearchResults = searchResults
                };

                searchEngineResults.Add(searchEngineResult);
            }

            if (homePageViewModel.SearchYahoo)
            {
                searchResults = searchService.Search(homePageViewModel.SearchPhrase,
                                                         homePageViewModel.Url,
                                                         Resources.Enums.SearchEnginesEnum.Yahoo);

                searchEngineResult = new SearchEngineResult()
                {
                    SearchEngine = Resources.Enums.SearchEnginesEnum.Yahoo.ToString(),
                    SearchResults = searchResults
                };

                searchEngineResults.Add(searchEngineResult);
            }

            searchResultViewModel.SearchEngineResults = searchEngineResults;

            return searchResultViewModel;
        }
    }
}