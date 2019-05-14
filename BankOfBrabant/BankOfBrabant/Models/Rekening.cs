using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    enum RekeningTypes    {        BETAAL = 0x02,        SPAAR = 0x03,        DEPOSIT = 0x04,        INTERN = 0x05    }    class Rekening    {        public ulong ID        {            get;            private set;        }        public string Nummer        {            get;            private set;        }        public RekeningTypes Type        {            get;            private set;        }        public decimal Saldo        {            get;            set;        }        public float RentePercentage        {            get;            set;        }        public Rekening()        {        }        public Rekening(string rekeningNummer, RekeningTypes type, decimal saldo, float rentePercentage)        {            ID = ulong.MaxValue; //invalid need to get a new one in the database
            Nummer = rekeningNummer; //can only be set once upon creation of a new account
            Type = type;            Saldo = saldo;            RentePercentage = rentePercentage;        }        public Rekening(DataRow row)        {            ID = (ulong)(long)row["ID"];            Nummer = row["RekeningNummer"].ToString();            Type = (RekeningTypes)(byte)(sbyte)row["RekeningType"];            Saldo = (decimal)row["Saldo"];            RentePercentage = (float)row["RentePercentage"];        }    }
}
