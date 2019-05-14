using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankOfBrabant.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult zetopscherm(string naam, string cars)
        {
            ViewBag.Naam = naam;
            ViewBag.Cars = cars;
            return View();
        }

        
    }
}