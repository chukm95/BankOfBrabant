using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankOfBrabant.Controllers
{
    public class RekeningController : Controller
    {
        public IActionResult Rekening()
        {
            return View();
        }

        public IActionResult geefweer(string rekeningtype)
        {
            ViewBag.Rekening = rekeningtype;
            return View();
        }
    }
}