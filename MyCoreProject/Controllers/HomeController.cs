using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCoreProject.Models;
using MyCoreWebApplication2.Models;

namespace MyCoreWebApplication2.Controllers
{
    public class HomeController : Controller
    {

        TestContext db;
        public HomeController(TestContext context)
        {
            db = context;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View(db.Tests.ToList());
            //return View();
            //return Content("Hello ASP.NET MVC 6");            
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
