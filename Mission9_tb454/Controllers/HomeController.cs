using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9_tb454.Models;
using Mission9_tb454.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_tb454.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int numResults = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(c => c.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * numResults)
                .Take(numResults),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == bookCategory).Count()), //ProjectType = Category for me
                    BooksPerPage = numResults,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
