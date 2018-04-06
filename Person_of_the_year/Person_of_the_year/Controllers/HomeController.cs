using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Person_of_the_year.Controllers
{

    /* Portions of this code was copied from 
     Amanda Iverson and Phil Werner
         */

    public class HomeController : Controller
    { //methods inside controllers are called actions

        [HttpGet]
        
        public ViewResult Index (int id)
        {
            List<string> myList = new List<string>() { };
            return View();
        }


        /* This is a posting method takes in two arguments integers
        and redirects to the Results page */
        [HttpPost]
        public IActionResult Index(int StartYear, int EndYear)
        {
            return RedirectToAction("Results", new { StartYear, EndYear });
        }

        
    }
}
