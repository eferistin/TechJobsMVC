using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all") // if the search chosen (searchType) equals to "all" one of the option specified in ListController.columnChoices
            {
                List<Dictionary<string, string>> searchword = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = searchword;
                return View("Index");
            }
            else if (searchType != "all")
            {
                List<Dictionary<string, string>> searchword = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = searchword;
                return View("Index");
            }
            else // if searchType == null, not chosen
            {
                string Notfound = "You must specfic a proper search term.";
                ViewBag.jobs = Notfound;
                return View("Index");
            }

            
        }


    }
}
