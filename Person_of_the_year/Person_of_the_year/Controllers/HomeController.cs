using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Person_of_the_year.Controllers
{
    public class HomeController : Controller
    { //methods inside controllers are called actions


      
        
        public ViewResult Index (int id)
        {
            string name = "Tiger";
            return View(name);
        }
        
    }
}
