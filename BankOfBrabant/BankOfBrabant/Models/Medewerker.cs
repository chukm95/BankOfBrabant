using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static BankOfBrabant.Models.Klant;

namespace BankOfBrabant.Models
{
    class Medewerker
    {
        public ulong ID
        {
            get;
            private set;
        }

        public string Voornaam
        {
            get;
            set;
        }
        public string Tussenvoegsel
        {
            get;
            set;
        }

        public string Achternaam
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Adres
        {
            get;
            set;
        }

        public Geslachten Geslacht
        {
            get;
            set;
        }

        public Medewerker()
        {

        }

        public Medewerker(string voornaam, string tussenvoegsel, string achternaam, string email, string adres, Geslachten geslacht)
        {
            ID = ulong.MaxValue; //invalid need to get a new one in database
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            Email = email;
            Adres = adres;
            Geslacht = geslacht;
        }

        public Medewerker(DataRow row)
        {
            ID = (ulong)(long)row["ID"];
            Voornaam = row["Voornaam"].ToString();
            Tussenvoegsel = row["Tussenvoegsel"].ToString();
            Achternaam = row["Achternaam"].ToString();
            Email = row["Email"].ToString();
            Adres = row["Adres"].ToString();
            Geslacht = (Geslachten)(byte)(sbyte)row["Geslacht"];
        }
    }

}
