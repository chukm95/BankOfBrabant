using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfBrabant.Models;
using Hangfire;
using Microsoft.EntityFrameworkCore;

/**
 * Userstory sprint 3
 * Functie "Aflossing" geschreven door 
 * 
 * Functie zorgt ervoor dat er per maand word afgelost door gebruik te maken van
 * "Hangfire", een backround task API
 * 
 * Nathaniel Veldkamp
 */


namespace BankOfBrabant.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankOfBrabantContext _context;

        public HomeController(BankOfBrabantContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            RecurringJob.AddOrUpdate(
            () => Aflossing(),
            Cron.Monthly);

            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // functie aflossing
        
        public void Aflossing()
        {
            // loop voor alle producten
           foreach(Products p in _context.Products)
            {

                // query voor account waar de account ID == product client ID
                var query =
              from ac in _context.Account                                                                                                                                           
              where ac.ClientId == p.ClientId
              select ac;

                // als de product type een persoonlijke lening is
                if (p.ProductType.Equals(Products.ProductTypes.PERSONAL))
                {

                    // account van de client vinden
                    foreach (Account a in query)
                    {

                        // zeker maken dat de account een betaal rekening is
                        if (a.AccountType.Equals(Account.AccountTypes.PAYMENT))
                        {

                            decimal month = (decimal)p.MonthlyPayment;
                            decimal currentLoan = (decimal) p.CurrentLoan;
                            decimal iRateDec = (decimal)p.InterestRate;
                            decimal interest = currentLoan * (iRateDec / 100);
                            decimal newBalance = a.Balance - (month + interest);

                            a.Balance = newBalance;
                            Console.WriteLine("New Personal Balance: " + newBalance);

                            decimal monthPay = month + interest;
                            decimal amountPaidBack = (decimal)p.PaidBack;
                            decimal newAmount = amountPaidBack + monthPay;

                            // er word afgelost
                            p.PaidBack = (double)newAmount;

                            //als de alle schuld is afgelost word de product verwijderd
                            if(p.PaidBack == p.CurrentLoan)
                            {
                                _context.Remove(_context.Products.Single(pr => pr.ID == p.ID));
                            }
                        }

                    }
                    //als de product type Doorlopend krediet is
                }else if (p.ProductType.Equals(Products.ProductTypes.CREDIT))
                {

                    // loop voor account van bovenstaande query
                    foreach (Account a in query)
                    {

                        // als het een betaal rekeking is
                        if (a.AccountType.Equals(Account.AccountTypes.PAYMENT))
                        {

                            decimal currentLoan = (decimal)p.CurrentLoan;
                            decimal iRateDec = (decimal)p.InterestRate;
                            decimal interest = currentLoan * (iRateDec / 100);
                            decimal TwoPercent = (decimal)2.0;
                            decimal TwoPercentOfCurrent  = currentLoan * (TwoPercent / 100);
                            decimal newBalance = a.Balance - (TwoPercentOfCurrent + interest);

                            
                            a.Balance = newBalance;
                            Console.WriteLine("New Credit Balance: " + newBalance);

                            decimal monthPay = TwoPercentOfCurrent + interest;
                            decimal amountPaidBack = (decimal)p.PaidBack;
                            decimal newAmount = amountPaidBack + monthPay;

                            // de aflossing
                            p.PaidBack = (double)newAmount;

                            //als alle schuld is afgelost word het product verwijderd
                            if(p.PaidBack == p.CurrentLoan)
                            {
                                _context.Remove(_context.Products.Single(pr => pr.ID == p.ID));
                            }

                        }

                    }
                }

            }
                

           // alle aanpassingen worden in de database opgeslagen dus is er officieel afgelost
            try
            {

                _context.SaveChanges();

            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Source);
            }

        }
    }
}
