using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfBrabant.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankOfBrabant.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult CreateAccount()
        {
            AccountAbstract account = new DepositAccount(10,20,"5");
            return View(account);
        }

        public IActionResult overboeken()
        {
            ViewBag.rekeningnummer = "NL INGB 00080088";
            return View();
        }
               
        public ActionResult CreateButton_Click()
        {
            ViewBag.Message = "Account created";
            return View();
        }

    }
}
