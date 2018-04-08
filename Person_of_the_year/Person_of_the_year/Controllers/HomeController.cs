using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Person_of_the_year.Models;

namespace Person_of_the_year.Controllers
{

    /* Portions of this code was copied from 
     Amanda Iverson and Phil Werner
         */

    public class HomeController : Controller
    { //methods inside controllers are called actions
        
        //This is the get method grabbing from the Index view and return a View()
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //This is a post Method posting to the Index to the Results page
        [HttpPost]
        // Index page must take in two parameters Start, End
        public IActionResult Index(int startYear, int endYear)
        {
            //This shows a Redirection to the "Results Page"
            return RedirectToAction("Results", new { startYear, endYear });
        }

        /* This is a posting method takes in two arguments integers
        and redirects to the Results page */
        public IActionResult Results(int startYear, int endYear)
        {
          
            //Constuctor funtion to redirect to person of the year
            TimePerson people = new TimePerson();

            return View(people.GetPersons(startYear, endYear));
        }

        
    }
}
