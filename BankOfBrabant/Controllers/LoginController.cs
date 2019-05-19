/*
    author: Davey
    date: 19-05-2019
    last edited: 19-05-2019
    changes:
    19-05-2019     created
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfBrabant.Models;


namespace BankOfBrabant.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Change_Press(String UserType)
        {
            if (UserType == "Employee")
            {
                return RedirectToAction(nameof(Change_Press_Employee));
            }
            else
            {
                return RedirectToAction(nameof(Change_Press_Accountholder));
            }
        }

        public IActionResult Change_Press_Employee()
        {
            return View();
        }

        public IActionResult Change_Press_Accountholder()
        {
            return View();
        }

        public IActionResult Login_Accountholder(string passNumber, int pincode)
        {
            return RedirectToAction(nameof(Login_Result));
        }

        public IActionResult Login_Employee(string Firstname, string password)
        {
            //database search 
            //if(Firstname.Equals)
            return RedirectToAction(nameof(Login_Result));
        }

        public IActionResult Login_Result()
        {
            ViewBag.Message = "Welcome to the Bank of Brabant.";
            return View();
        }
    }
}