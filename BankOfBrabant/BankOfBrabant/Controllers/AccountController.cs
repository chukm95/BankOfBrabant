using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfBrabant.Models;
using SqlConnection.DatabaseShit;
using SqlConnection.DatabaseShit.Entiteiten;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankOfBrabant.Controllers
{
    public class AccountController : Controller
    {
        SQLManager sqm = SQLManager.Initialize("94.208.132.186", "23412", "testdb", "user02", "X7f6EysG8jrgNQvp");
        // GET: /<controller>/
        public IActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult CreateButton(String accountType, int PassNumber, string AccountName, int PinCode)
        {
            sqm = SQLManager.Instance;

            if (PassNumber != 0 && !String.IsNullOrEmpty(AccountName) && PinCode != 0)
            {
                if (CheckDatabase(PassNumber, AccountName, PinCode))
                {
                    if (accountType.Equals("depositAccount"))
                    {
                        AccountAbstract account = new DepositAccount(500, 1, 6, PassNumber, PinCode, AccountName);
                        Rekening rekening = new Rekening("1", accountType, 500, 1, AccountName, PassNumber, PinCode);
                        sqm.CreateRekening(rekening);
                        ViewBag.Message = accountType;
                        return View(account);
                    }
                    else if (accountType.Equals("savingsAccount"))
                    {
                        AccountAbstract account = new SavingsAccount(500, 1, 5, PassNumber, PinCode, AccountName);
                        ViewBag.Message = account.AccountName;
                        Rekening rekening = new Rekening("1", accountType, 500, 1, AccountName, PassNumber, PinCode);
                        sqm.CreateRekening(rekening);
                        return View(account);
                    }
                    else
                    {
                        AccountAbstract account = new SpendingAccount(500, 1, 7, PassNumber, PinCode, AccountName);
                        ViewBag.Message = accountType;
                        Rekening rekening = new Rekening("1", accountType, 500, 1, AccountName, PassNumber, PinCode);
                        sqm.CreateRekening(rekening);
                        return View(account);
                    }
                }

                else
                {
                    ViewBag.Message = "Either the account name is already in use, or your pass-pincode combination is invalid";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Please fill in your passnumber and desired account name.";
                return View();
            }
        }

        //check of account name of pasnummer correct zijn
        public bool CheckDatabase(int passnumber, string accountname, int pinCode)
        {

            try
            {
                sqm = SQLManager.Instance;
                Rekening[] rekeningen = sqm.ReadRekeningByPassNumber(passnumber);

                if (rekeningen.LongLength == 0)
                {
                    return true;
                }
                if (rekeningen[0].PinCode == pinCode)
                {
                    foreach (Rekening rekening in rekeningen)
                    {
                        if (rekening.RekeningNaam.Equals(accountname))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }      
    }
}
