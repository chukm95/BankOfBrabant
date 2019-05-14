using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class RekeningOverzicht
    {
        public int Rekeningnummer { get; set; }
        public string Naam { get; set; }
        public string Rentepercentage { get; set; }
        public int Saldo { get; set; }
        public int TypeRekening { get; set; }
        public int ID { get; set; }
    }
}
