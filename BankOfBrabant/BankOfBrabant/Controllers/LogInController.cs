using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SqlConnection.DatabaseShit.Entiteiten;
using SqlConnection.DatabaseShit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankOfBrabant.Controllers
{
    public class LogInController : Controller
    {
        SQLManager sqm = SQLManager.Initialize("94.208.132.186", "23412", "testdb", "user02", "X7f6EysG8jrgNQvp");
        // GET: /<controller>/
        public IActionResult LoginScreen()
        {
            return View();
        }

        public IActionResult LoginPress()
        {
            ViewBag.Message = "You have succesfully logged in";
            return View();
        }

        public bool CheckDatabase(int passNumber, int pinCode)
        {
            ulong id = (ulong)passNumber;
            Klant klant = new Klant();
            klant = sqm.ReadKlantById(id);
            if (klant.ID == (ulong)pinCode) 
            {
                return true;
            }
            return false;
        }
    }
}
