using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfBrabant.Models;
using SqlConnection.DatabaseShit;

namespace BankOfBrabant.Controllers
{
    public class KlantenController : Controller
    {
        
        public IActionResult KlantAanmaken()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateKlant(Klant klant)
        {

            if (ModelState.IsValid)
            {

                SQLManager.Initialize("94.208.132.186", "23412", "testdb", "user02", "X7f6EysG8jrgNQvp");
                SQLManager sqm = SQLManager.Instance;

                Klant dbKlantCreate = new Klant()
                {
                    Voornaam = klant.Voornaam,
                    Tussenvoegsel = klant.Tussenvoegsel,
                    Achternaam = klant.Achternaam,
                    Email = klant.Email,
                    Adres = klant.Adres,
                    Geslacht = klant.Geslacht,
                    KvkNummer = klant.KvkNummer,
                    BKRPositief = klant.BKRPositief,
                    Blacklisted = klant.Blacklisted,
                    PaspoortCheck = klant.PaspoortCheck
                };

                sqm.CreateKlant(dbKlantCreate);
            }
          
            return View("KlantAanmaken", klant);
        }
    }
}