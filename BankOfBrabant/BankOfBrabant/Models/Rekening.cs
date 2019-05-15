using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    enum RekeningTypes
    {
        BETAAL = 0x02,
        SPAAR = 0x03,
        DEPOSIT = 0x04,
        INTERN = 0x05
    }

    class Rekening

    {
        public ulong ID
        {
            get;
            private set;
        }

        public string Nummer
        {
            get;
            private set;
        }

        public string AccountType
        {
            get;
            set;
        }

        public RekeningTypes Type
        {
            get;
            private set;
        }

        public decimal Saldo
        {
            get;
            set;
        }

        public float RentePercentage
        {
            get;
            set;
        }

        public string RekeningNaam
        {
            get;
            set;
        }

        public int PassNumber
        {
            get;
            set;
        }

        public int PinCode
        {
            get;
            set;
        }

        public Rekening()
        {

        }

        public Rekening(string rekeningNummer, string accountType, decimal saldo, float rentePercentage, string rekeningNaam, int passNumber, int pinCode)
        {
            ID = ulong.MaxValue; //invalid need to get a new one in the database
            Nummer = rekeningNummer; //can only be set once upon creation of a new account
            //Type = type;
            AccountType = accountType;
            Saldo = saldo;
            RentePercentage = rentePercentage;
            RekeningNaam = rekeningNaam;
            PassNumber = passNumber;
            PinCode = pinCode;
        }

        public Rekening(DataRow row)
        {
            ID = (ulong)(long)row["ID"];
            Nummer = row["RekeningNummer"].ToString();
            //Type = (RekeningTypes)(byte)(sbyte)row["RekeningType"];
            AccountType = row["RekeningType"].ToString();
            Saldo = (decimal)row["Saldo"];
            RentePercentage = (float)row["RentePercentage"];
            RekeningNaam = row["RekeningNaam"].ToString();
            PassNumber = (int)row["PassNummer"];
            PinCode = (int)row["PinCode"];
        }


    }

}
