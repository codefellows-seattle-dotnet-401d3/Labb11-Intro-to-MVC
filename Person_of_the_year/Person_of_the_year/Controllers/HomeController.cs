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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        /* This is a posting method takes in two arguments integers
        and redirects to the Results page */
        public IActionResult Results(int startYear, int endYear)
        {
            ViewData["Message"] = "Here are your Person(s) of the Year";

            TimePerson people = new TimePerson();

            return View(people.GetPersons(startYear, endYear));
        }

        
    }
}
