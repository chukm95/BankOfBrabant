using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfBrabant.Models;
using SqlConnection.DatabaseShit;

namespace BankOfBrabant.Controllers
{
    public class TransactiesController : Controller
    {

        private List<Transactie> transactie;
        public IActionResult TransactieLog()
        {

            SQLManager.Initialize("94.208.132.186", "23412", "testdb", "user02", "X7f6EysG8jrgNQvp");
            SQLManager sqm = SQLManager.Instance;

            transactie = new List<Transactie>();

            Transactie[] trans = sqm.ReadAllFromTransacties();

            transactie = trans.OfType<Transactie>().ToList();

            return View(transactie);
        }
    }
}