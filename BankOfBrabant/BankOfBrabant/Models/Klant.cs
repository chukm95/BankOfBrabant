using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace BankOfBrabant.Models
{

    public class Klant
    {

        public enum Geslachten
        {
            MAN = 0x01,
            VROUW = 0x02,
            OVERIG = 0x03
        }

        public ulong ID
        {
            get;
            private set;
        }
        [Required]
        public string Voornaam
        {
            get;
            set;
        }
        [Display(Name = "Tussen voegsel")]
        public string Tussenvoegsel
        {
            get;
            set;
        }

        [Required]
        public string Achternaam
        {
            get;
            set;
        }

        [Required]
        public string Email
        {
            get;
            set;
        }

        [Required]
        public string Adres
        {
            get;
            set;
        }

        [Required]
        public Geslachten Geslacht
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Kvk nummer")]
        [StringLength(8)]
        public string KvkNummer
        {
            get;
            set;
        }
        
        [Display(Name = "BKR positief")]
        public bool BKRPositief
        {
            get;
            set;
        }
        
        public bool Blacklisted
        {
            get;
            set;
        }
    
        [Display(Name = "Paspoort check")]
        public bool PaspoortCheck
        {
            get;
            set;
        }

        public Klant()
        {

        }

        public Klant(string voornaam, string tussenvoegsel, string achternaam, string email, string adres, Geslachten geslacht, string kvknummer, bool bkrPositief, bool blacklisted, bool paspoortCheck)
        {
            ID = ulong.MaxValue;//invalid need get one in the database
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            Email = email;
            Adres = adres;
            Geslacht = geslacht;
            KvkNummer = kvknummer;
            BKRPositief = bkrPositief;
            Blacklisted = blacklisted;
            PaspoortCheck = paspoortCheck;

        }

        public Klant(DataRow row)
        {
            ID = (ulong)(long)row["ID"];
            Voornaam = row["Voornaam"].ToString();
            Tussenvoegsel = row["Tussenvoegsel"].ToString();
            Achternaam = row["Achternaam"].ToString();
            Email = row["Email"].ToString();
            Adres = row["Adres"].ToString();
            Geslacht = (Geslachten)(byte)(sbyte)row["Geslacht"];
            KvkNummer = row["KVKNummer"].ToString();
            BKRPositief = (bool)row["BKRPositief"];
            Blacklisted = (bool)row["Blacklisted"];
            PaspoortCheck = (bool)row["PaspoortCheck"];
        }

    }
}
