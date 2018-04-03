using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimePerson.Models;

namespace TimePerson.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult Results(int startYear, int endYear)
        {
            ViewData["Message"] = "Here are your Person(s) of the Year";

            People people = new People();

            return View(people.GetThePeople(startYear, endYear));
        }
    }
}
