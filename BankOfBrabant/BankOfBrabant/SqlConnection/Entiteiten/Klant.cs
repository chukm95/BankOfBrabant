using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlConnection.DatabaseShit.Entiteiten
{
    enum Geslachten
    {
        MAN = 0x01,
        VROUW = 0x02,
        OVERIG = 0x03
    }

    class Klant
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

        public string KvkNummer
        {
            get;
            set;
        }

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
