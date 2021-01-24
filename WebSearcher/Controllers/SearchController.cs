using System.Web.Mvc;
using WebSearcher.Interfaces;
using WebSearcher.Models;

namespace WebSearcher.Controllers
{
    public class SearchController : Controller
    {
        private ISearchResultsViewModelBuilder searchResultsViewModelBuilder;

        public SearchController(ISearchResultsViewModelBuilder searchResultsViewModelBuilder)
        {
            this.searchResultsViewModelBuilder = searchResultsViewModelBuilder;
        }

        /// <summary>
        /// The Search action method
        /// </summary>
        /// <param name="homePageViewModel">The home page view model</param>
        /// <returns>Action result</returns>
        [HttpPost]
        public ActionResult Search(HomePageViewModel homePageViewModel)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction(Resources.Constants.Constants.Common.IndexAction, 
                                        Resources.Constants.Constants.Common.HomeController);
            }

            var model = searchResultsViewModelBuilder.GetSearchResultsViewModel(homePageViewModel);

            return View(Resources.Constants.Constants.Common.SearchResultsViewName, model);
        }
    }
}