using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class Transactie
    {
        public ulong ID { get; private set; }
        public String Verstuurder { get; set; }
        public String Ontvanger { get; set; }
        public double Euros { get; set; }
        public DateTime Datum { get; set; }

        public Transactie()
        {

        }

        public Transactie(string verstuurder, string ontvanger, double euros, DateTime datum)
        {
            ID = ulong.MaxValue;// invalid db needs one
            Verstuurder = verstuurder;
            Ontvanger = ontvanger;
            Euros = euros;
            Datum = datum;
        }

        public Transactie(DataRow row)
        {
            ID = (ulong)(long)row["ID"];
            Verstuurder = row["Verstuurder"].ToString();
            Ontvanger = row["Ontvanger"].ToString();
            String s = row["Euros"].ToString();
            Euros = Double.Parse(s);
            String st = row["Datum"].ToString();
            Datum = DateTime.Parse(st);


        }

    }

}
